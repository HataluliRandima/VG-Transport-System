﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Twilio.Types;
using Twilio;
using VG_TransportAPI.DTO.Driver;
 
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;
using System.Net.NetworkInformation;


 
 
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {

        //for twilio
         string accountSid = "AC5fd9ce6310c09e539ea7bc7b33add82f";
        string authToken = "e1c2a55c3ddb254c008f1b98e5454537";


        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;

        private readonly IEMailServices _emailServices;

        public DriversController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }

        //Register driver in the database
       
        [HttpPost]
        [Route("regdriver")]
        public async Task<IActionResult> Regdriver([FromBody] RegDriver driver)
        {

            try
            {

                var user = _context.Drivers.Where(u => u.DEmail == driver.DEmail).FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("Driver has already  exist");
                }
                else
                {
                    user = new Driver();

                    user.DName = driver.DName;
                    user.DSurname = driver.DSurname;
                    user.DEmail = driver.DEmail;
                    user.DPhone = driver.DPhone;
                    user.DPassword = "123456";
                    user.DStatus = "Active";
                    user.DUrl = UrlBorrow();
                    user.DBlocked = "UnBlocked";
                    // user.DsDoc3 = "null";

                    // send email to driver 
                    string subject = "Account Registration";
                    string body12 = "Your Account  has been succesful activated wait for another email with login details user your email and password is  " + user.DPassword;
                    ///log in and chane details and complete your acctou addresses
                    await _emailServices.SendEmailAsync(user.DEmail, subject, body12);


                    //send sms to the driver 
                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: body12,
                    from: new Twilio.Types.PhoneNumber("+16073182030"),
                        to: new Twilio.Types.PhoneNumber("+27" + user.DPhone)
                    );

                    Console.WriteLine(message.Sid);

                    _context.Drivers.Add(user);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful registered a driver" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //Creating a url for the the driver
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


                var isDuplicate = _context.Drivers.Any(a => a.DUrl == newRandomUrl);

                if (!isDuplicate)
                {
                    boolflag = false;
                }


            }
            return newRandomUrl;
        }
    }
}
