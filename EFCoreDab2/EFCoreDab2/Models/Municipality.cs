using System;
using System.Collections.Generic;

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
    }
}
