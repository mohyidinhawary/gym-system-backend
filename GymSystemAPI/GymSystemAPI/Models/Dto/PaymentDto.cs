namespace GymSystemAPI.Models.Dto
{
    public class PaymentDto
    {
        public long Amount { get; set; }
        public string CardNumber { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string CVV { get; set; } = "";
    }
}
