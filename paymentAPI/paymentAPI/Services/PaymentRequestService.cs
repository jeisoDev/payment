using MercadoPago.Resource.Payment;
using MercadoPago.Client.Payment;
using paymentAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MercadoPago.Config;
using MercadoPago.Client;

namespace paymentAPI.Services
{
    public class PaymentRequestService : IPaymentRequestService
    {
        public async Task<IEnumerable<Payment>> GetAllPaymentRequestsAsync(string accessToken)
        {
            MercadoPagoConfig.AccessToken = accessToken;

            var client = new PaymentClient();
            var searchRequest = new PaymentSearchRequest
            {
                // Adicione critérios de busca se necessário
            };
            var searchResult = await client.SearchAsync(searchRequest);

            return searchResult.Results;
        }

        private class PaymentSearchRequest : SearchRequest
        {
        }
    }
}