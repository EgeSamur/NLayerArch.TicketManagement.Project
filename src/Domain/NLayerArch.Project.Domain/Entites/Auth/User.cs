using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites.Auth
{
    public class User : BaseEntity
    {
        public string EmailAddress { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
