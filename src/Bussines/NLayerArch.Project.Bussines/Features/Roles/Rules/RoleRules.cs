using NLayerArch.Project.Bussines.Base.Rules;
using NLayerArch.Project.Bussines.Features.Users.Rules.Exceptions;
using NLayerArch.Project.Domain.Entites.Auth;

namespace NLayerArch.Project.Bussines.Features.Roles.Rules
{
    public class RoleRules : BaseRules
    {
        public Task EnsureRoleIsNotExists(Role? user)
        {
            if(user is not null)
            {
                throw new RoleIsAlreadyExistsException();
            }
            return Task.CompletedTask;
        }

        public Task EnsureIsRoleExists(Role? user)
        {
            if (user is null)
            {
                throw new RoleDoesNotExistException();
            }
            return Task.CompletedTask;
        }
    }
}
