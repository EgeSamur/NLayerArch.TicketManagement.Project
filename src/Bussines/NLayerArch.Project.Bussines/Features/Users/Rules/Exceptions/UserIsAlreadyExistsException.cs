using NLayerArch.Project.Bussines.Base.Rules;

namespace NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions
{
    public class UserIsAlreadyExistsException : BaseException
    {
        public UserIsAlreadyExistsException() : base("User is already exists.") { }
    }
}
