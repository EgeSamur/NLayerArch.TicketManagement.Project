using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites
{
    public class EventType : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
