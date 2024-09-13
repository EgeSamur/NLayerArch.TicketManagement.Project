using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.DataAccess.Configrations
{
    public class RoleOperationClaimConfiguration : IEntityTypeConfiguration<RoleOperationClaim>
    {
        public void Configure(EntityTypeBuilder<RoleOperationClaim> builder)
        {
            builder.HasKey(roc => roc.Id);

            builder.HasOne(roc => roc.Role)
                   .WithMany(r => r.RoleOperationClaims)
                   .HasForeignKey(roc => roc.RoleId);

            builder.HasOne(roc => roc.OperationClaim)
                   .WithMany(oc => oc.RoleOperationClaims)
                   .HasForeignKey(roc => roc.OperationClaimId);
        }
    }
}
