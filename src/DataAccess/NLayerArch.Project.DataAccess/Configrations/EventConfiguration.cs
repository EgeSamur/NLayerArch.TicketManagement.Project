using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Date).IsRequired();

            builder.HasOne(e => e.EventType)
                   .WithMany()
                   .HasForeignKey(e => e.EventTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Venue)
                   .WithMany()
                   .HasForeignKey(e => e.VenueId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
