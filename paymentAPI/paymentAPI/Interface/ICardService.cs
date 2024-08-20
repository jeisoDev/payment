using System.Threading.Tasks;
using paymentAPI.Model;

namespace paymentAPI.Interfaces
{
    public interface ICardService
    {
        Task<CardTokenResponse> CreateCardAsync(string accessToken, string cardNumber, int expirationMonth, int expirationYear, string securityCode, string cardholderName);
    }
}