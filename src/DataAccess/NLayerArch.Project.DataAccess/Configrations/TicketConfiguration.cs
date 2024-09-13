using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.SeatNumber).HasMaxLength(10);

            builder.HasOne(t => t.Event)
                   .WithMany()
                   .HasForeignKey(t => t.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.TicketType)
                   .WithMany()
                   .HasForeignKey(t => t.TicketTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
