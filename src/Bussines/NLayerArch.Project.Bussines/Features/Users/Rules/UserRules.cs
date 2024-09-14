using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions;
using NLayerArch.Project.Domain.Entites.Auth;
using NLayerArch.Project.Security.Hashing;

namespace NLayerArch.Project.Bussines.Features.Users.Rules
{
    public class UserRules : BaseRules
    {
        public Task EnsureUserIsNotExists(User? user)
        {
            if(user is not null)
            {
                throw new UserIsAlreadyExistsException();
            }
            return Task.CompletedTask;
        }

        public Task EnsureIsUserExists(User? user)
        {
            if (user is null)
            {
                throw new UserDoesNotExistException();
            }
            return Task.CompletedTask;
        }

    
    }
}
