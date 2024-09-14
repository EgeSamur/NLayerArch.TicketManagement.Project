using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.Bussines.Features.Users.Dtos;
using NLayerArch.Project.Bussines.Features.Users.Rules;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.UnitOfWorks;
using NLayerArch.Project.Domain.Entites.Auth;
using NLayerArch.Project.Security.Hashing;

namespace NLayerArch.Project.Bussines.Features.Users.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly UserRules _userRules;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IRoleRepository roleRepository, UserRules userRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRules = userRules;
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            User? user = await _userRepository.GetAsync(x => x.EmailAddress == dto.EmailAddress);
            await _userRules.EnsureUserIsNotExists(user);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            HashingHelper.CreatePasswordHash(dto.Password, out var passwordHash, out var passwordSalt);
            var entity = _mapper.Map<User>(dto);
            entity.Id= Guid.NewGuid();
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            entity.UserRoles = new List<UserRole>();
            entity.CreatedBy = currentUserId;

            // bu kısımda tokenı kullanan user çekilip onun rolü dahilindeki default rol eklenebilir
            // mesela kendisi event düzenleyici rolünde üse bu kullanıcıda event düzenleyici olabilir.


            await _userRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _userRepository.GetAsync(i => i.Id == id, enableTracking: true);
            await _userRules.EnsureIsUserExists(entity);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            entity!.IsDeleted = true;
            entity.DeletedDate = DateTime.UtcNow;
            entity.DeletedBy = currentUserId;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetListResponse<UserDto>> GetListAsync(PageRequest? pageRequest = null)
        {
            var size = pageRequest?.Size ?? 0;
            var index = pageRequest?.Index ?? 0;
            var isAll = (pageRequest?.IsAll ?? true) || index == 0 && size == 0;

            var users = await _userRepository.GetAllByPagingAsync(
                pageSize: size,
                currentPage: index,
                include: i => i
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .ThenInclude(x=>x.RoleOperationClaims) 
                    .ThenInclude(x=>x.OperationClaim),
                predicate: i => 
                   i.IsDeleted == false,
                orderBy: i => i.OrderBy(x => x.CreatedDate)
            );;
            var result = _mapper.Map<GetListResponse<UserDto>>(users);
            return result;
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userRepository.GetAsync(i => i.EmailAddress == dto.EmailAdress,
            enableTracking: true);
            await _userRules.EnsureIsUserExists(user);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            if (!HashingHelper.VerifyPasswordHash(dto.OldPassword, user!.PasswordHash, user.PasswordSalt))
                throw new Exception("Wrong Password!");
            HashingHelper.CreatePasswordHash(dto.NewPassword, out var passwordHash, out var passwordSalt);

            user!.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UpdatedDate = DateTime.UtcNow;
            user.UpdatedBy = currentUserId;
            await _userRepository.UpdateAsync(user);
        }

        public async Task SetRolesAsync(SetUserRolesDto dto)
        {
            var user = await _userRepository.GetAsync(i => i.Id == dto.UserId,
           include: i => i.Include(x => x.UserRoles)
               .ThenInclude(x => x.Role),
           enableTracking: true);
            await _userRules.EnsureIsUserExists(user);
            user!.UserRoles.Clear();

            foreach (var roleId in dto.RoleIds)
            {
                user.UserRoles.Add(new UserRole
                {
                    UserId = user.Id,
                    RoleId = roleId
                });
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateUserDto dto)
        {
            var entity = await _userRepository.GetAsync(i => i.Id == dto.Id, enableTracking: true);
            await _userRules.EnsureIsUserExists(entity);
            var currentUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            _mapper.Map(dto, entity);  // entity = _mapper.Map<User>(dto)
            // enabletracking açık olduğu için _userRepository.Update(entity) yapmıyoruz.
            entity.UpdatedBy = currentUserId;
            entity.UpdatedDate = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
