using MercadoPago.Resource.Payment;
using System.Threading.Tasks;
using MercadoPago.Client.CardToken;
using MercadoPago.Resource.CardToken;
using paymentAPI.Model;

namespace paymentAPI.Interface
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(string accessToken, decimal amount, string description, string email, string firstName, string lastName, string identificationType, string identificationNumber);
        Task<Payment> CreateCreditCardPaymentAsync(string accessToken, decimal amount, string description, string email, string firstName, string lastName, string identificationType, string identificationNumber, int Installments, string cardToken, string BandeiraPagamento);
        Task<Payment> GetPaymentStatusAsync(long paymentId);
    }
}