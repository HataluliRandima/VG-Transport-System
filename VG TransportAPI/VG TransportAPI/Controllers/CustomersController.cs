using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VG_TransportAPI.DTO.Car;
using VG_TransportAPI.DTO.Customer;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;
using VG_TransportAPI.Tools;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;

        private readonly IEMailServices _emailServices;

        public CustomersController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }


        //register a customer
        [HttpPost]
        [Route("memberregister")]
        public async Task<IActionResult> Customerregister([FromBody] RegCustomer memb)
        {
            try
            {
                var user = _context.Customers.Where(u => u.CEmail == memb.CEmail).FirstOrDefault();
                if (user != null)
                {
                    return BadRequest("customer has already Register");
                }
                else
                {
                    user = new Customer();

                    user.CName = memb.CName;
                    user.CSurname = memb.CSurname;
                    user.CEmail = memb.CEmail;
                    user.CNumber = memb.CNumber;
                    user.CAdd1 = memb.CAdd1;
                    user.CAdd2 = memb.CAdd2;
                    user.CPassword = Password.hashPassword(memb.CPassword);
                    user.CStatus = "InActive";
                    user.CBlocked = "UnBlock";
                    user.CUrl = UrlBorrow() ;
                  //  user.MemberDateCreate = DateTime.Now;


                    _context.Customers.Add(user);
                    await _context.SaveChangesAsync();

                    return Ok(new { message = "Successful registered a customer" });


                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Creating a url for the the customer
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


        //create jwt token for authetication
        //for creating the jwt token
        private JwtSecurityToken getToken(List<Claim> authClaim)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        //Login for customer 
        [HttpPost]
        [Route("customerlogin")]
        public async Task<IActionResult> Customerlogin([FromBody] LoginCustomer user)
        {
            try
            {
                String password = Password.hashPassword(user.CPassword);
                var user11 = _context.Customers.Where(u => u.CEmail == user.CEmail && u.CPassword == password).FirstOrDefault();
                if (user11 == null)
                {
                    return BadRequest("Either email or password is incorrect!!");
                }
                else
                {
                    List<Claim> authClaim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user11.CEmail),
                        new Claim ("CustomerID",user11.CId.ToString())
                    };

                    var token = this.getToken(authClaim);

                    return Ok(new
                    {
                        message = "Customer login in the system",
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //Get all  Customers
        [HttpGet]
        [Route("getallcustomers")]
        public async Task<IActionResult> getallcustomers()
        {

            try
            {
                List<Customer> listuser = _context.Customers.ToList();
                if (listuser != null)
                {
                    return Ok(listuser);
                }
                return Ok("They are no customers in the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //get each ctomer based on id 
        [HttpGet]
        [Route("customerby/{id}")]
        public async Task<IActionResult> getmerchantid(int id)
        {

            var user11 = _context.Customers.Where(u => u.CId == id).FirstOrDefault();

            if (user11 == null)
            {
                return BadRequest("Cant find the specific user");

            }

            return Ok(user11);
           

        }

        //get a customer thats currently log in in the system
        [HttpGet]
        [Route("customer/current")]
        public async Task<IActionResult> getcurrentmerchant()
        {
            int id = Convert.ToInt32(HttpContext.User.FindFirstValue("CustomerID"));

            if (id == null || id <= 0)
            {
                return BadRequest("You are not log in");
            }
            var user11 = _context.Customers.Select(t => new
            {
                t.CId,
                t.CName,
                t.CSurname,
                t.CEmail,
                t.CNumber,
                t.CAdd1,
                t.CAdd2,
                t.CStatus,
                t.CBlocked,
            }).Where(u => u.CId == id).FirstOrDefault();
           // if()
            return Ok(user11);

    

            // return Ok(new { userID = id });
        }




        //update customer profile by the customer
        [HttpPut]
        [Route("updatecustomer/{id}")]
        public async Task<ActionResult> customerupdate([FromBody] UpdateCustomer user, int id)
        {

            try
            {

                var dbu = _context.Customers.Where(u => u.CId == id).FirstOrDefault<Customer>();


                if (dbu == null)
                {
                    return BadRequest("customer not found");
                }

                
                dbu.CName = user.CName;
                dbu.CSurname = user.CSurname;
                dbu.CNumber = user.CNumber;
                dbu.CAdd1 = user.CAdd1;
                dbu.CAdd2 = user.CAdd2;

                await _context.SaveChangesAsync();

                return Ok(new { message = "customer profile successful updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //change password for the forget password
        [HttpPut]
        [Route("customerpass")]
        public async Task<ActionResult> customerupdatepassword([FromBody] ChangePasswordC user, string url)
        {

            try
            {

                var dbu = _context.Customers.Where(u => u.CUrl == url).FirstOrDefault<Customer>();


                if (dbu == null)
                {
                    return BadRequest("customer not found");
                }


                dbu.CPassword = user.CPassword;
             

                await _context.SaveChangesAsync();

                return Ok(new { message = "customer    successful updated password" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
