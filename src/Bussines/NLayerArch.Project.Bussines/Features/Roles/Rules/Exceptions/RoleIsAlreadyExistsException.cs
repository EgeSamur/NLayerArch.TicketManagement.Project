using NLayerArch.Project.Bussines.Base.Rules;

namespace NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions
{
    public class RoleIsAlreadyExistsException : BaseException
    {
        public RoleIsAlreadyExistsException() : base("Role is already exists.") { }
    }
}
