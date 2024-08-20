using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using paymentAPI.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace paymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentRequestController : ControllerBase
    {
        private readonly IPaymentRequestService _paymentRequestService;

        public PaymentRequestController(IPaymentRequestService paymentRequestService)
        {
            _paymentRequestService = paymentRequestService;
        }

        [HttpGet("Payment/List")]
        public async Task<IActionResult> GetAllPaymentRequests([FromHeader] string accessToken)
        {
            IEnumerable<Payment> payments = await _paymentRequestService.GetAllPaymentRequestsAsync(accessToken);
            return Ok(payments);
        }
    }
}