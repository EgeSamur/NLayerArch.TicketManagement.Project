using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
