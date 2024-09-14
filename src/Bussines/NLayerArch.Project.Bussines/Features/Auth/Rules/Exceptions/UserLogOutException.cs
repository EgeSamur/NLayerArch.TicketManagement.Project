using NLayerArch.Project.Bussines.Base.Rules;

namespace NLayerArch.Project.Bussines.Features.Auth.Rules.Exceptions
{
    public class UserLogOutException : BaseException
    {
        public UserLogOutException() : base("User logged out.") { }
    }
}
