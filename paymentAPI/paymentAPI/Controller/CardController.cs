using Microsoft.AspNetCore.Mvc;
using paymentAPI.Interfaces;
using paymentAPI.Models;
using System.Threading.Tasks;

namespace paymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost("create-card")]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardRequest request, [FromHeader] string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                return Unauthorized("Access token is missing.");
            }

            var cardTokenResponse = await _cardService.CreateCardAsync(
                accessToken,
                request.CardNumber,
                request.ExpirationMonth,
                request.ExpirationYear,
                request.SecurityCode,
                request.CardholderName);

            return Ok(cardTokenResponse);
        }
    }
}