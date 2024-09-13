using NLayerArch.Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArch.Project.Domain.Entites
{
    public class Venue : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
