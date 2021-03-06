using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class RoomProperty
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }

        public virtual Room Room { get; set; }
        
        public override string ToString()
        {
            var a = $"RoomPropId: {Id} RoomId: {RoomId} Name: {Name} Room: {Room}\n";
            return a;
        }
    }
}
