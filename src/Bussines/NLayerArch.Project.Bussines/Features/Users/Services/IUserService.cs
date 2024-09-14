using NLayerArch.Project.Bussines.Base.RequestBase;
using NLayerArch.Project.Bussines.Base.ResponseStructure;
using NLayerArch.Project.Bussines.Features.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Users.Services
{
    public interface IUserService
    {
        Task CreateAsync(CreateUserDto dto);
        Task UpdateAsync(UpdateUserDto dto);
        Task DeleteAsync(Guid id);
        Task<GetListResponse<UserDto>> GetListAsync(PageRequest? pageRequest);
      
        Task ResetPasswordAsync(ResetPasswordDto dto);
        // role permision yani claim atama olacak.
        //Task SetPermissionsAsync(SetUserPermissionsDto dto);
        Task SetRolesAsync(SetUserRolesDto dto);
    }
}
