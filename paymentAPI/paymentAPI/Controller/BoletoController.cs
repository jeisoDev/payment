using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using paymentAPI.Interfaces;
using paymentAPI.Models;
using System.Threading.Tasks;

namespace paymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;

        public BoletoController(IBoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost("create/Boleto")]
        public async Task<IActionResult> CreateBoletoPayment([FromBody] BoletoRequest request, [FromHeader] string accessToken)
        {
            request.Validate();

            Payment payment = await _boletoService.CreateBoletoPaymentAsync(
                accessToken,
                request.Amount, 
                request.Description, 
                request.Email, 
                request.FirstName, 
                request.LastName, 
                request.IdentificationType, 
                request.IdentificationNumber,
                request.ExpirationDate
            );
            return Ok(payment);
        }
    }
}