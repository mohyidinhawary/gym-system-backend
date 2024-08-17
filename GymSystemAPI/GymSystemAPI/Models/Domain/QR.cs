namespace GymSystemAPI.Models.Domain
{
    public class QR
    {
        public int Id { get; set; }
       
        public byte[] QRCodeImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
