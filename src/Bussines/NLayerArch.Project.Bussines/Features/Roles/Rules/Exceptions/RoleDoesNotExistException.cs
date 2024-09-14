using NLayerArch.Project.Bussines.Base.Rules;

namespace NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions
{
    public class RoleDoesNotExistException : BaseException
    {
        public RoleDoesNotExistException() : base("Role does not exist.") { }
    }
}
