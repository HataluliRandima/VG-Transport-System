using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System.Linq;
using System.Security.Claims;
using Twilio.TwiML.Messaging;
using VG_TransportAPI.DTO.DriverStorage;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;
using VG_TransportAPI.Tools;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverStorageController : ControllerBase
    {
        //for database connection
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;

        private readonly IEMailServices _emailServices;

        public DriverStorageController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }


        //Driver request to be part of the system
        [HttpPost]
        [Route("reqdriver")]
        public async Task<IActionResult> Reqdriver([FromBody] DriverStor driver)
        {

            try
            {

                var user = _context.DriverStorages.Where(u => u.DsEmail == driver.DsEmail).FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("Driver has already submitted the request");
                }
                else
                {
                    user = new DriverStorage();

                    user.DsName = driver.DsName;
                    user.DsSurname = driver.DsSurname;
                    user.DsEmail = driver.DsEmail;
                    user.DsNumber = driver.DsNumber;
                    user.DsStatus = "InActive";
                    user.DsStatusAct = "UnVerified";
                    user.DsDoc1 = "null";
                    user.DsDoc2 = "null";
                    user.DsDoc3 = "null";


                    _context.DriverStorages.Add(user);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful submitted your request" });
                }

                }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //get all the drivers who are not verified
        [HttpGet]
        [Route("getunverdriver")]
        public async Task<IActionResult> getunverified()
        {
            try
            {
                List<DriverStorage> listuser = _context.DriverStorages.Where(u => u.DsStatus == "InActive").OrderByDescending(t => t.DsId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Drivers in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //get all the drivers who are   verified
        [HttpGet]
        [Route("getverdriver")]
        public async Task<IActionResult> getverified()
        {
            try
            {
                List<DriverStorage> listuser = _context.DriverStorages.Where(u => u.DsStatus == "Active").OrderByDescending(t => t.DsId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Drivers in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //get all the drivers who are   declined
        [HttpGet]
        [Route("getdecldriver")]
        public async Task<IActionResult> getdeclined()
        {
            try
            {
                List<DriverStorage> listuser = _context.DriverStorages.Where(u => u.DsStatus == "Decline").OrderByDescending(t => t.DsId).ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no Drivers in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get all  drivers in the storage
        [HttpGet]
        [Route("getalldrivers")]
        public async Task<IActionResult> getalldrivers()
        {

            try
            {
                List<DriverStorage> listuser = _context.DriverStorages.ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no driver in the storage");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        //Edit the driver storage status
        [HttpPut]
        [Route("editdriver/{id}")]
        public async Task<ActionResult> memberrupdate([FromBody] DriverStupdate user, int id)
        {
            //  int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("MemberID"));
            string email ;
            string subject = "Request Response";

            try
            {

           
            var dbu =   _context.DriverStorages.Where(u => u.DsId == id).FirstOrDefault<DriverStorage>() ;

            //if (userID == null || userID <= 0)
            //{
            //    return BadRequest("Yuu are not log in");
            //}
                if (dbu == null)
            {

                     
                    return BadRequest("driver not found");
            }


                dbu.DsStatus = user.DsStatus;
                dbu.DsStatusAct = user.DsStatusAct;
            // email = retemail(id);
                ///string body = "Your status is " + dbu.DsStatus;
            await _context.SaveChangesAsync();

                //await _emailServices.SendEmailAsync(email, subject, body);

                return Ok(new { message = "Driver status successful updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       private string retemail(int id)
        {
            string email12 = "";


            var isDuplicate = _context.DriverStorages.Select(t => new
            {
                t.DsId,

               email12 = t.DsEmail
            } ). Where(a => a.DsId == id).FirstOrDefault();

            return email12;
        }


        //email for succesful driver
        [HttpPost]
        [Route("sendemailDV")]
        public async Task<IActionResult> sendemailver(string ToEmail )
        {
            try
            {

                
                string subject = "Account Request response"  ;
               string body = "Your Account  has been succesful activated wait for another email with login details "  ;

                await _emailServices.SendEmailAsync(ToEmail, subject, body);

                return Ok("Email sent to the driver");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //email for declined driver
        [HttpPost]
        [Route("sendemailDC")]
        public async Task<IActionResult> sendemaildecl(string ToEmail)
        {
            try
            {


                string subject = "Account Request response";
                string body = "Your Account  its declined because your information its not preoven ";

                await _emailServices.SendEmailAsync(ToEmail, subject, body);

                return Ok("Email sent to the driver");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //function to return email when passed an id
        //[HttpGet]
        //[Route("getalldri")]
        //public async Task<String> retemail(int id)
        //{
        //    //var isDuplicate = _context.DriverStorages.Any(a => a.BorrowUrl == newRandomUrl);
        //    String email = "";
        //    var user11 = _context.DriverStorages.Any(t =>


        //        t.DsId == id




        //);


        //    return  email;
        //}

        //delete specific driver from the storage
        [HttpDelete]
        [Route("deletedriver/{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {

            var delm = await _context.DriverStorages.FindAsync(id);

            if (delm == null)
            {
                return BadRequest("driver not found");
            }

            _context.DriverStorages.Remove(delm);
            await _context.SaveChangesAsync();

            return Ok(new { message = "driver has been deleted successful" });
        }



    }



}
