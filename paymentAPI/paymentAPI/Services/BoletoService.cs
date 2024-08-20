using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Resource.Payment;
using MercadoPago.Config;
using paymentAPI.Interfaces;
using System;
using System.Threading.Tasks;
using MercadoPago.Error;

namespace paymentAPI.Services
{
    public class BoletoService : IBoletoService
    {
        public async Task<Payment> CreateBoletoPaymentAsync(string accessToken,decimal amount, string description, string email, string firstName, string lastName, string identificationType, string identificationNumber, DateTime expirationDate)
        {
            try
            {
                // Configurar o SDK do Mercado Pago com o accessToken fornecido
                MercadoPagoConfig.AccessToken = accessToken;

                var paymentRequest = new PaymentCreateRequest
                {
                    TransactionAmount = amount,
                    Description = description,
                    PaymentMethodId = "bolbradesco", // Método de pagamento Boleto Bradesco
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
                    },
                    DateOfExpiration = expirationDate
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
    }
}