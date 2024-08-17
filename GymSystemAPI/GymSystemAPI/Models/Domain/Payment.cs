namespace GymSystemAPI.Models.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public long Amount { get; set; }
        public string CardNumber { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string CVV { get; set; } = "";

        // Foreign key property
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
