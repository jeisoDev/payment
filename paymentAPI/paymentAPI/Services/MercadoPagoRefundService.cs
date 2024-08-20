using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using paymentAPI.Interfaces;
using System.Threading.Tasks;

namespace paymentAPI.Services
{
    public class MercadoPagoRefundService : IMercadoPagoRefundService
    {
        public async Task<PaymentRefund> RefundPaymentAsync(string token, string paymentId)
        {
            MercadoPagoConfig.AccessToken = token;

            var client = new PaymentClient();
            try
            {
                // Correct method call with appropriate arguments
                PaymentRefund refund = await client.RefundAsync(long.Parse(paymentId), null, null, default);
                return refund;
            }
            catch (Exception)
            {
                // Log the exception (ex) if necessary
                return null;
            }
        }
    }
}