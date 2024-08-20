using MercadoPago.Client.CardToken;
using MercadoPago.Resource.CardToken;
using MercadoPago.Error;
using paymentAPI.Interfaces;
using paymentAPI.Model;
using System;
using System.Threading.Tasks;
using MercadoPago.Config;

namespace paymentAPI.Services
{
    public class CardService : ICardService
    {
        public async Task<CardTokenResponse> CreateCardAsync(string accessToken, string cardNumber, int expirationMonth, int expirationYear, string securityCode, string cardholderName)
        {
            try
            {
                // Configurar o SDK do Mercado Pago com o accessToken fornecido
                MercadoPagoConfig.AccessToken = accessToken;

                var cardTokenRequest = new CardTokenCreateRequest
                {
                    CardNumber = cardNumber,
                    ExpirationMonth = expirationMonth,
                    ExpirationYear = expirationYear,
                    SecurityCode = securityCode,
                    Cardholder = new CardTokenCardholderRequest
                    {
                        Name = cardholderName
                    }
                };

                var client = new CardTokenClient();
                CardToken cardToken = await client.CreateAsync(cardTokenRequest);

                return new CardTokenResponse { Token = cardToken.Id };
            }
            catch (MercadoPagoApiException ex)
            {
                // Log the error details for debugging
                Console.WriteLine($"Error response from API. Status code: {ex.StatusCode}, API message: {ex.ApiError.Message}");
                throw;
            }
        }
    }

    internal class CardTokenCardholderRequest
    {
        public required string Name { get; set; }
    }

    internal class CardTokenCreateRequest : MercadoPago.Client.CardToken.CardTokenRequest
    {
        public required string CardNumber { get; set; }
        public required int ExpirationMonth { get; set; }
        public required int ExpirationYear { get; set; }
        public new required string SecurityCode { get; set; }
        public required object Cardholder { get; set; }
    }
}