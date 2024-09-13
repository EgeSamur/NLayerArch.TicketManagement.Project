using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class SponsorshipConfiguration : IEntityTypeConfiguration<Sponsorship>
    {
        public void Configure(EntityTypeBuilder<Sponsorship> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SponsorName).IsRequired().HasMaxLength(150);
            builder.Property(s => s.Amount).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(s => s.Event)
                   .WithMany()
                   .HasForeignKey(s => s.EventId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
