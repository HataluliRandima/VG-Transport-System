using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VG_TransportAPI.DTO.Payment;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        //for database connection
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;


        //for sending email to the client or the driver 
        private readonly IEMailServices _emailServices;

        public PaymentsController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }

        //add payment to a specific order
        [HttpPost]
        [Route("addpayorder")]
        public async Task<IActionResult> addpaymenttoorder([FromBody] PayOrder ord)
        {

            try
            {
                //create the strings for messages
                string payy = " ";
                string pio = " ";

                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("CustomerID"));

                if(ord == null)
                {
                    return BadRequest("You cant pay empty order");
                }

                if(userID == null && userID <=0)
                {
                    return BadRequest("You are not log in , please log in");
                }

                var dbs = new Payment();

                dbs.CId = userID;
                dbs.PAmount = ord.PAmount;
                //dbs.PStatus = "Paid";
                dbs.OId = ord.OId;
                dbs.PType = ord.PType;
                dbs.PPaydrive = "NO";

                

                if (dbs.PType == "CSD")
                {
                    dbs.PStatus = "Not paid";
                    pio = " You will pay the driver";

                   // return Ok(new { message = " You will pay the driver" });
                }
                else
                {
                    dbs.PStatus = "Paid";
                    payy = " You have paid the order";
                    //return Ok(new { message = " You have paid the order" });
                }

                _context.Payments.Add(dbs);
                await _context.SaveChangesAsync();

                return Ok(new { message = payy + pio
                });

                //thinking of the usage of an if statement to return different outcomes

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
