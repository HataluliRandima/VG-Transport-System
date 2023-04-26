using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SmsTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendsController : ControllerBase
    {
        string accountSid = "AC5fd9ce6310c09e539ea7bc7b33add82f";
        string authToken = "e1c2a55c3ddb254c008f1b98e5454537";

        [HttpPost("SendText")]
        public ActionResult SendText(string phoneNumber, string bodymessage)
        {

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: bodymessage,
                from: new Twilio.Types.PhoneNumber("+16073182030"),
                to: new Twilio.Types.PhoneNumber("+27" + phoneNumber)
            );

            Console.WriteLine(message.Sid);

            return StatusCode(200, new { message = message.Sid });


        }
    }
    }
