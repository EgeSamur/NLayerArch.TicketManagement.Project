using NLayerArch.Project.Bussines.Base.Rules;

namespace NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions
{
    public class UserDoesNotExistException : BaseException
    {
        public UserDoesNotExistException() : base("User does not exist.") { }
    }
}
