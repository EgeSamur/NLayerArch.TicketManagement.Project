using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasKey(e => e.Id);  // BaseEntity'deki Id'yi primary key olarak ayarlıyoruz
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100); // Name zorunlu ve maksimum 100 karakter
            builder.Property(e => e.Description).HasMaxLength(250); // Description opsiyonel
        }
    }
}
