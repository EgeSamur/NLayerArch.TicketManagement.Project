using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Name).IsRequired().HasMaxLength(150);
            builder.Property(v => v.Location).IsRequired().HasMaxLength(300);
            builder.Property(v => v.Capacity).IsRequired();
        }
    }
}
