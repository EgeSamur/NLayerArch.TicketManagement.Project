using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites
{
    public class Ticket : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public Guid TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SeatNumber { get; set; } // Belirli bir koltuk numarası varsa
    }
}
