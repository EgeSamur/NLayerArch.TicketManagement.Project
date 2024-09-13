﻿using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.DataAccess.Context;
using NLayerArch.Project.DataAccess.Repositories.Abstract;
using NLayerArch.Project.DataAccess.Repositories.Concrete.Base;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Repositories.Concrete
{
    public class SponsorshipRepository : BaseRepository<Sponsorship>, ISponsorshipRepository
    {
        public SponsorshipRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
