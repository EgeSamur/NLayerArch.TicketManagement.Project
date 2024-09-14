using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.Bussines.Features.Auth.Rules.Exceptions;
using NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions;
using NLayerArch.Project.Domain.Entites.Auth;
using NLayerArch.Project.Security.Hashing;
using UserDoesNotExistException = NLayerArch.Project.Bussines.Features.Auth.Rules.Exceptions.UserDoesNotExistException;
using UserIsAlreadyExistsException = NLayerArch.Project.Bussines.Features.Auth.Rules.Exceptions.UserIsAlreadyExistsException;

namespace NLayerArch.Project.Bussines.Features.Auth.Rules
{
    public class AuthRules : BaseRules
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

        public async Task EnsurePasswordMatches(User user, string password)
        {
            if (!HashingHelper.VerifyPasswordHash(password, user!.PasswordHash, user.PasswordSalt))
                throw new Exception("Login information not verified");
            await Task.CompletedTask;
        }

        public Task EnsureUserNotLogOut(DateTime? refreshTokenExpireTime)
        {
            if (refreshTokenExpireTime <= DateTime.Now)
            {
                throw new UserLogOutException();
            }
            return Task.CompletedTask;
        }
    }
}
