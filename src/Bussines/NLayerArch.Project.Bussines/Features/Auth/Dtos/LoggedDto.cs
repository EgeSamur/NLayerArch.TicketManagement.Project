﻿using NLayerArch.Project.Security.JWT;

namespace NLayerArch.Project.Bussines.Features.Auth.Dtos
{
    public class LoggedDto
    {
        public Guid Id { get; set; }
        public AccessToken AccessToken { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Roles { get; set; }

    }
}
