namespace EFCoreDab2.Models
{
    public partial class Access
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int PhoneNr { get; set; }
        public int DriverLicense { get; set; }

        public override string ToString()
        {
            return
                $"MemberId: {MemberId}, MemberName: {Member?.Name}, PhoneNr: {PhoneNr}, DriverLicense: {DriverLicense}";
        }
    }
}