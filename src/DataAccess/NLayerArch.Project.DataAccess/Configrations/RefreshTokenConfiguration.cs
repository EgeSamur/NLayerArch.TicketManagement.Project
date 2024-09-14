using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}
