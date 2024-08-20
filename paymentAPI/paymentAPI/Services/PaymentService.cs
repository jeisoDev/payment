using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using MercadoPago.Config;
using paymentAPI.Interface;
using paymentAPI.Models;
using MercadoPago.Error;

namespace paymentAPI.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<Payment> CreatePaymentAsync(string accessToken, decimal amount, string description, string email, string firstName, string lastName, string identificationType, string identificationNumber)
        {
            try
            {
                // Configurar o SDK do Mercado Pago com a chave de acesso para cada requisição
                MercadoPagoConfig.AccessToken = accessToken;

                var paymentRequest = new PaymentCreateRequest
                {
                    TransactionAmount = amount,
                    Description = description,
                    PaymentMethodId = "pix", // "pix", "credit_card", "bolbradesco", etc.
                    Payer = new PaymentPayerRequest
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Identification = new IdentificationRequest
                        {
                            Type = identificationType,
                            Number = identificationNumber
                        }
                    }
                };

                var client = new PaymentClient();
                Payment payment = await client.CreateAsync(paymentRequest);

                // Retornar a resposta completa do pagamento
                return payment;
            }
            catch (MercadoPagoApiException ex)
            {
                // Log the error details for debugging
                Console.WriteLine($"Error response from API. Status code: {ex.StatusCode}, API message: {ex.ApiError.Message}");
                throw;
            }
        }

        public async Task<Payment> CreateCreditCardPaymentAsync(
            string accessToken,
            decimal amount, 
            string description, 
            string email, 
            string firstName, 
            string lastName, 
            string identificationType, 
            string identificationNumber, 
            int installments, 
            string cardToken,
            string bandeiraPagamento)
        {
            // Validar o número de parcelas
            if (installments <= 0)
            {
                throw new ArgumentException("The number of installments must be greater than zero.");
            }

            try
            {
                // Configurar o SDK do Mercado Pago com a chave de acesso para cada requisição
                MercadoPagoConfig.AccessToken = accessToken;

                var paymentRequest = new PaymentCreateRequest
                {
                    TransactionAmount = amount,
                    Token = cardToken,
                    Description = description,
                    Installments = installments,
                    PaymentMethodId = bandeiraPagamento, // "visa", "mastercard", etc.
                    Payer = new PaymentPayerRequest
                    {
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        Identification = new IdentificationRequest
                        {
                            Type = identificationType,
                            Number = identificationNumber
                        }
                    }
                };

                var paymentClient = new PaymentClient();
                Payment payment = await paymentClient.CreateAsync(paymentRequest);

                return payment;
            }
            catch (MercadoPagoApiException ex)
            {
                // Log the error details for debugging
                Console.WriteLine($"Error response from API. Status code: {ex.StatusCode}, API message: {ex.ApiError.Message}");
                throw;
            }
        }

        public async Task<Payment> GetPaymentStatusAsync(long paymentId)
        {
            try
            {
                var client = new PaymentClient();
                Payment payment = await client.GetAsync(paymentId);

                // Retornar a resposta completa do pagamento
                return payment;
            }
            catch (MercadoPagoApiException ex)
            {
                // Log the error details for debugging
                Console.WriteLine($"Error response from API. Status code: {ex.StatusCode}, API message: {ex.ApiError.Message}");
                throw;
            }
        }
    }
}