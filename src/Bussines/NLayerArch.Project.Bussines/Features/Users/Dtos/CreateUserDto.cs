using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Bussines.Features.Users.Dtos
{
    public class CreateUserDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
