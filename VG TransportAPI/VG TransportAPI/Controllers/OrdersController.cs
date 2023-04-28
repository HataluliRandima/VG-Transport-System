using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VG_TransportAPI.DTO.Order;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        //for database connection
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;


        //for sending email  to the client or driver 
        private readonly IEMailServices _emailServices;

        public OrdersController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }

        //customer processing orders for the booking that has been accepted
        [HttpPost]
        [Route("addorder")]
        public async Task<IActionResult> addordercust([FromBody] TakeOrder ord )
        {

            try
            {

                string urlsend;

                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("CustomerID"));


                if (ord == null)
                {
                    return BadRequest("You cant order empty book");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newborrow = new Order();

                newborrow.CId = userID;
                newborrow.BId = ord.BId;
                newborrow.ODetailSen1 = ord.ODetailSen1;
                newborrow.ODetailSen2 = ord.ODetailSen2;
                newborrow.ODetailRec1= ord.ODetailRec1;
                newborrow.ODetailRec2 = ord.ODetailRec2;
                newborrow.ODesc = ord.ODesc;
                newborrow.OUrlcode = Urlorder();
                newborrow.OStatus = "InActive";
                urlsend = newborrow.OUrlcode;
                newborrow.OPaydriver = "NotPaid";
                //others to come here below 


                _context.Orders.Add(newborrow);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "keep this url for tracking and Orders has been submitted",
                    urlToken = urlsend
                });




                

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        //Creating a url for the orders of booking 
        private string Urlorder()
        {
            var newRandomUrl = string.Empty;
            Random rand = new Random();

            var boolflag = true;

            while (boolflag)
            {
                newRandomUrl = "";

                for (int a = 0; a < 2; a++)
                {
                    var randNum = rand.Next(1, 9);
                    var randChar = (char)rand.Next('a', 'z');
                    var randChar1 = (char)rand.Next('A', 'Z');

                    newRandomUrl += randChar1.ToString();
                    newRandomUrl += randChar.ToString();
                    newRandomUrl += randNum.ToString();
                }


                var isDuplicate = _context.Bookings.Any(a => a.BUrlcode == newRandomUrl);

                if (!isDuplicate)
                {
                    boolflag = false;
                }


            }
            return newRandomUrl;
        }
        //eix the emai has to be done for telling customer uri their order has been assigne to the driver 

        //asign a driver to a specific order and pass the id of the driver
        [HttpPut]
        [Route("assigndriver/{id}")]
        public async Task<IActionResult> driverassign([FromBody] AssignDrive  drv, int id)
        {

            try
            {
                var dbu = await _context.Orders.FindAsync(id);

                if(dbu == null)
                {
                    return BadRequest("There is no that specific order");
                }

                dbu.DId = drv.DId;
                dbu.OStatus = "Driver assigned";

                await _context.SaveChangesAsync();

                return Ok(new { message = "Driver has been assigned to the order" });
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



            //do the emails staff to update the customer on their order status
    }
}
