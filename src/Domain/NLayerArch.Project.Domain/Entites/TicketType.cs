using NLayerArch.Project.Domain.Common;
using NLayerArch.Project.Domain.Enums;

namespace NLayerArch.Project.Domain.Entites
{
    public class TicketType : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public TicketTypeName Name { get; set; } // VIP, Genel Giriş vb.
        public decimal Price { get; set; }
        public int Quota { get; set; } // Kontenjan
    }
}
