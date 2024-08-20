using Microsoft.AspNetCore.Mvc;
using paymentAPI.Interface;
using MercadoPago.Resource.Payment;
using paymentAPI.Model;
using System.Threading.Tasks;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create/Pix")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentRequest request, [FromHeader] string accessToken)
        {
            Payment paymentResponse = await _paymentService.CreatePaymentAsync(
                accessToken,
                request.Amount, 
                request.Description, 
                request.Email, 
                request.FirstName, 
                request.LastName, 
                request.IdentificationType, 
                request.IdentificationNumber
            );
            return Ok(paymentResponse);
        }

        [HttpPost("create/credit-card")]
        public async Task<IActionResult> CreateCreditCardPayment([FromBody] CreditCardPaymentRequest request, [FromHeader] string accessToken)
        {
            Payment payment = await _paymentService.CreateCreditCardPaymentAsync(
                accessToken,
                request.Amount, 
                request.Description, 
                request.Email, 
                request.FirstName, 
                request.LastName, 
                request.IdentificationType, 
                request.IdentificationNumber,
                request.Installments,
                request.CardToken,
                request.BandeiraPagamento
            );
            return Ok(payment);
        }

        [HttpGet("status/{paymentId}")]
        public async Task<IActionResult> GetPaymentStatus(long paymentId)
        {
            Payment payment = await _paymentService.GetPaymentStatusAsync(paymentId);
            return Ok(payment);
        }
    }
}