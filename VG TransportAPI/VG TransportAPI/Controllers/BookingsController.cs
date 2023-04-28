using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System.Security.Claims;
using VG_TransportAPI.DTO.Booking;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;

        private readonly IEMailServices _emailServices;

        public BookingsController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }



        //Book transportation
        [HttpPost]
        [Route("booktrip")]
        public async Task<IActionResult> Bookooking([FromBody] AddBooking brk)
        {
            String urlsend;
            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("CustomerID"));


                if (brk == null)
                {
                    return BadRequest("You cant borrow empty book");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newborrow = new Booking();

                newborrow.CId = userID;
                newborrow.BDate = brk.BDate;
                newborrow.BTime = brk.BTime;
                newborrow.BCartype = brk.BCartype;
                newborrow.BUrlcode = UrlBorrow();
                newborrow.BStatus = "InActive";
                urlsend = newborrow.BUrlcode;
                //others to come here below 


                _context.Bookings.Add(newborrow);
                await _context.SaveChangesAsync();
                return Ok(new
                {
                    message = "keep this url and borrow has been submitted",
                    urlToken = urlsend
                });


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Creating a url for the borrowing of a book 
        private string UrlBorrow()
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

    }
}
