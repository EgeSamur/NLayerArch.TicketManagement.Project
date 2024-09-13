using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Comment).HasMaxLength(500);

            builder.HasOne(r => r.Event)
                   .WithMany()
                   .HasForeignKey(r => r.EventId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.ReviewDate).IsRequired();
        }
    }
}
