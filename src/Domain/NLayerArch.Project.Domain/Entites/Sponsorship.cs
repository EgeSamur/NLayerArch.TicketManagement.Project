using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites
{
    public class Sponsorship : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public string? SponsorName { get; set; }
        public decimal Amount { get; set; } // Sponsor edilen miktar
    }
}
