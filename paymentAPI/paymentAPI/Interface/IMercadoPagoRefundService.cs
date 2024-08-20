using MercadoPago.Resource.Payment;
using System.Threading.Tasks;

namespace paymentAPI.Interfaces
{
    public interface IMercadoPagoRefundService
    {
        Task<PaymentRefund> RefundPaymentAsync(string token, string paymentId);
    }
}