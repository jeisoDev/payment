namespace paymentAPI.Model
{
    public class PaymentRequest
    {
        public required decimal Amount { get; set; }
        public required string Description { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentificationType { get; set; }
        public required string IdentificationNumber { get; set; }
    }
}