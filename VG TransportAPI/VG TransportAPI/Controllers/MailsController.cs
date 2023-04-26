using VG_TransportAPI.Interfaces;
 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {

        private readonly IEMailServices _emailServices;

        public MailsController (IEMailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost]
        [Route("sendemail")]
        public async Task<IActionResult> sendemail([FromBody] Mailrequest rew)
        {

            try
            {

            //    await _emailServices.SendEmailAsync(rew);

                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
