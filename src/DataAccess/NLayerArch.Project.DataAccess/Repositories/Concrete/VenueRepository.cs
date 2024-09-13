using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete
{
    public class VenueRepository : BaseRepository<Venue>, IVenueRepository
    {
        public VenueRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
