namespace paymentAPI.Model
{
    public class CreateCreditCardPaymentRequest
    {
        public required string CardToken { get; set; }
        public required decimal Amount { get; set; }
        public required int Installments { get; set; }
        public required string Description { get; set; }
        public required string Email { get; set; }
    }
}