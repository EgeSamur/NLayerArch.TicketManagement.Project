using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(t => t.Quota).IsRequired();

            builder.HasOne(t => t.Event)
                   .WithMany()
                   .HasForeignKey(t => t.EventId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
