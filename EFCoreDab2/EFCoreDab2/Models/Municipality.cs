using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class Municipality
    {
        public Municipality()
        {
            Rooms = new HashSet<Room>();
            Societies = new HashSet<Society>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cvr { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Society> Societies { get; set; }

        public override string ToString()
        {
            var a = $"Name: {Name} Id: {Id} Cvr: {Cvr}\n";
            a += String.Join("", Rooms.Select(room => $"Name: {room.Name}, Address: {room.Address}\n"));
            return a;
        }
    }
}