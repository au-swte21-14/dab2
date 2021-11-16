namespace EFCoreDab2.Models
{
    public partial class AccessKey
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }
}