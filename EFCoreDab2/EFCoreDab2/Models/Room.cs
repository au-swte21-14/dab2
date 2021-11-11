using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomProperties = new HashSet<RoomProperty>();
            RoomReservations = new HashSet<RoomReservation>();
        }

        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public int? Limit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Access { get; set; }

        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<RoomProperty> RoomProperties { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
    }
}
