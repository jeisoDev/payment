namespace paymentAPI.Models
{
    public class CreateCardRequest
    {
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
        public string CardholderName { get; set; }
    }
}