using NLayerArch.Project.Domain.Common;
using NLayerArch.Project.Domain.Enums;

namespace NLayerArch.Project.Domain.Entites
{
    public class Review : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
        public ReviewRate Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
