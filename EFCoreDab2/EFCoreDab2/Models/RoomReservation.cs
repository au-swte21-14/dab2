using System;
using System.Collections.Generic;
using System.Linq;

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
            var society = Member?.Society;
            var chairman = society?.Members?.First(m => m.IsChairman == true);
            var a =
                $"Booker: {Member?.Name}, Society: {society?.Name}, SocietyChairman: {chairman?.Name}, StartTime: {StartTime}, EndTime: {EndTime}\n";
            return a;
        }
    }
}