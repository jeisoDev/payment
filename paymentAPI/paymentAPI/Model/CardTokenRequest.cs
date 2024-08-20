namespace paymentAPI.Model
{
    public class CardTokenRequest
    {
        public required string CardNumber { get; set; }
        public required int ExpirationMonth { get; set; }
        public required int ExpirationYear { get; set; }
        public required string SecurityCode { get; set; }
        public required string CardholderName { get; set; }
    }
}