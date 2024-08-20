using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using paymentAPI.Interfaces;
using System.Threading.Tasks;

namespace paymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentRefundController : ControllerBase
    {
        private readonly IMercadoPagoRefundService _mercadoPagoRefundService;

        public PaymentRefundController(IMercadoPagoRefundService mercadoPagoRefundService)
        {
            _mercadoPagoRefundService = mercadoPagoRefundService;
        }

        [HttpPost("Payment/Refund")]
        public async Task<IActionResult> RefundPayment([FromHeader] string token, [FromBody] string paymentId)
        {
            PaymentRefund refund = await _mercadoPagoRefundService.RefundPaymentAsync(token, paymentId);

            if (refund != null)
            {
                return Ok(refund);
            }
            else
            {
                return BadRequest(new { success = false, message = "Failed to refund payment." });
            }
        }
    }
}