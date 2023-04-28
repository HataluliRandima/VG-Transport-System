using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Security.Claims;
using System.Security.Cryptography;
using VG_TransportAPI.DTO.FeedBack;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBacksController : ControllerBase
    {

         //connecting to the database
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;


        //sending email to the driver or the customer
        private readonly IEMailServices _emailServices;


        
        public FeedBacksController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }

        //add feed back by the customer 
        [HttpPost]
        [Route("addfeedC")]
        public async Task<IActionResult> feedbackcust([FromBody]CustomerFeed fs )
        {

            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("CustomerID"));

                if (fs == null)
                {
                    return BadRequest("You cant do feedbacl empty");
                }

                if (userID == null && userID <= 0)
                {
                    return BadRequest("You are not log in , please log in");
                }

                var newfeed = new Feedback();

                newfeed.CId = userID;
                newfeed.FMessageC = fs.FMessageC;
                newfeed.FRateC = fs.FRateC;
                newfeed.OId = fs.OId;

                _context.Feedbacks.Add(newfeed);
                await _context.SaveChangesAsync();

                return Ok(new { message = "your feedback has been submitted" });


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
