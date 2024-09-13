using NLayerArch.Project.Domain.Common;

namespace NLayerArch.Project.Domain.Entites
{
    public class Event : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsOnline { get; set; } = true;// Online etkinlik mi?
        public Guid EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public Guid VenueId { get; set; }
        public Venue Venue { get; set; } // mekan etkinlik yeri
    }
}
