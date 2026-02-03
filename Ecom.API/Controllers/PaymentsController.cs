using Ecom.Core.Entities;
using Ecom.Core.Entities.Order;
using Ecom.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.IO;
using System.Threading.Tasks;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }



        // Create payment method
        [Authorize]
        [HttpPost("Create")]
        public async Task<ActionResult<CustomerBasket>> Create(string basketId, int? deliveryId)
        {
            return await paymentService.CreateOrUpdatePaymentAsync(basketId, deliveryId);
        }

        const string endpointSecret = "whsec_18cf00274fc91bac91ad87d48a318da79aa3ba28977519d87351a7fa0a99cf8f";

        // Webhook for handling Stripe events
        [HttpPost("webhook")]
        public async Task<IActionResult> UpdateStatusWithStripe()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret, throwOnApiVersionMismatch: false);
                PaymentIntent intent;
                Orders orders;
                // Handle the event
                if (stripeEvent.Type == "payment_intent.payment_failed")
                {
                    intent = stripeEvent.Data.Object as PaymentIntent;
                    orders = await paymentService.UpdateOrderFaild(intent.Id);
                }
                else if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    intent = stripeEvent.Data.Object as PaymentIntent;
                    orders = await paymentService.UpdateOrderSuccess(intent.Id);
                }
                // ... handle other event types
                else
                {
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }
    }
}
