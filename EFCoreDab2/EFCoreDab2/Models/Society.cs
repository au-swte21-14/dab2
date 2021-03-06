using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace EFCoreDab2.Models
{
    public partial class Society
    {
        public Society()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        public string Name { get; set; }
        public int Cvr { get; set; }
        public string Address { get; set; }
        public string Activity { get; set; }

        public virtual Municipality Municipality { get; set; }
        public virtual ICollection<Member> Members { get; set; }

        public override string ToString()
        {
            var chairman = Members.FirstOrDefault(m => m.IsChairman == true);
            var a = $"SocietyId: {Id}, Name: {Name}, " +
                    $"Cvr: {Cvr}, Address: {Address}, Activity: {Activity}, Chairman: {chairman?.Name}, Municipality: {Municipality?.Name}";

            return a;
        }
    }
}