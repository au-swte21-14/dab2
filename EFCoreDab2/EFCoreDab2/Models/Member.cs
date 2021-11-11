using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class Member
    {
        public Member()
        {
            RoomReservations = new HashSet<RoomReservation>();
        }

        public int Id { get; set; }
        public int SocietyId { get; set; }
        public bool? IsChairman { get; set; }
        public string Name { get; set; }
        public int Cpr { get; set; }
        public string Address { get; set; }

        public virtual Society Society { get; set; }
        public virtual ICollection<RoomReservation> RoomReservations { get; set; }
        
        public override string ToString()
        {
            var a = $"MemberId: {Id} SocietyId: {SocietyId} IsChairman: {IsChairman} " +
                    $"Name: {Name} Cpr: {Cpr} Address: {Address} Society: {Society} RoomRess: {RoomReservations}\n";
            return a;
        }
    }
}
