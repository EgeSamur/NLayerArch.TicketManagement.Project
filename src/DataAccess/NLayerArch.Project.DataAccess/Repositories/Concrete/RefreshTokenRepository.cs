using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
