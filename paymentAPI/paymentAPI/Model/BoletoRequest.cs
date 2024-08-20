namespace paymentAPI.Models
{
    public class BoletoRequest
    {
        public required decimal Amount { get; set; }
        public required string Description { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string IdentificationType { get; set; }
        public required string IdentificationNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Validar o valor da transação
        public void Validate()
        {
            if (Amount <= 0)
            {
                throw new ArgumentException("The transaction amount must be greater than zero.");
            }
        }
    }
}