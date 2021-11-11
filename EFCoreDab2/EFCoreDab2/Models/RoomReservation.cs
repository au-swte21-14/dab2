using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class RoomReservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Member Member { get; set; }
        public virtual Room Room { get; set; }

        public override string ToString()
        {
            var a = $"Id: {Id} RoomId: {RoomId} MemberId: {MemberId} StartTime: {StartTime} EndTime: {EndTime}\n";
            return a;
        }
    }
}
