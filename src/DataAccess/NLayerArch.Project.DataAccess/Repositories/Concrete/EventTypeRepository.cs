using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete
{
    public class EventTypeRepository : BaseRepository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
