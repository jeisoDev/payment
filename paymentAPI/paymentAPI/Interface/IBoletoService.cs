using MercadoPago.Resource.Payment;
using System.Threading.Tasks;
using System;

namespace paymentAPI.Interfaces
{
    public interface IBoletoService
    {
        Task<Payment> CreateBoletoPaymentAsync(string accessToken,decimal amount, string description, string email, string firstName, string lastName, string identificationType, string identificationNumber, DateTime expirationDate);
    }
}