using MercadoPago.Resource.Payment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Interfaces
{
    public interface IPaymentRequestService
    {
        Task<IEnumerable<Payment>> GetAllPaymentRequestsAsync(string accessToken);
    }
}