using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

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
        public virtual ICollection<AccessKey> AccessKeys { get; set; }
        public string KeyPickupLocation { get; set; }
        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<RoomProperty> RoomProperties { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }

        public override string ToString()
        {
            var a = $"Name: {Name}, Id: {Id}, Limit: {Limit}, Address {Address}, Access: {Access}";
            return a;
        }

        public string GetBookedRooms()
        {
            var a = $"Name: {Name}, Address: {Address}\n";
            a += String.Join("\n", RoomReservations);
            return a;
        }
    }
}