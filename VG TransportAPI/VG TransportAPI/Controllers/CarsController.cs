using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using VG_TransportAPI.DTO.Car;
using VG_TransportAPI.DTO.DriverStorage;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        //database connection
        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;


        //usage for sending emails to the driver or customer 
        private readonly IEMailServices _emailServices;

        public CarsController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }

        //Add the car by the specific driver
        [HttpPost]
        [Route("addcar")]
        public async Task<IActionResult> addcars([FromForm] AddCar cr,IFormFile pdfFile)
        {

            try
            {
                var fiveMegaByte = 5 * 1024 * 1024;
                var pdfMimeType = "application/pdf";

                if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
                {
                    return BadRequest("file n t v");
                }

                var urlpdf = Guid.NewGuid().ToString() + ".pdf";
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "cars", urlpdf);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);
                }


                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("DriverID"));


                if (cr == null)
                {
                    return BadRequest("You cant add empty car");
                }

                if (userID == null || userID <= 0)
                {
                    return BadRequest("You are not log in, Please log in");
                }

                var newcar = new Car();

                newcar.DId = userID;
                newcar.CrName = cr.CrName;
                newcar.CrModel = cr.CrModel;
                newcar.CrType = cr.CrType;
                newcar.CrRegPlate = cr.CrRegPlate;
                newcar.CrPaper1 = urlpdf;
                //Usage of status of car to be verified
                newcar.CrPaper2 = "NotVerified";
                //Usage of status to see if the car its availabe for delivery
                newcar.CrDescription = "Available";
        
               
                _context.Cars.Add(newcar);
                await _context.SaveChangesAsync();

                return Ok(new { message = "You have succeful added the car but wait for the verification" });


   


    }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //download car documents those pdf files

        [HttpGet]
        [Route("download/{url}")]
        public IActionResult DownloadPdf(string url)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "cars", url);

            if (!System.IO.File.Exists(filepath))
            {
                return NotFound("File Not Found");
            }

            var pdfbytes = System.IO.File.ReadAllBytes(filepath);
            var file = File(pdfbytes, "application/pdf", url);

            return file;
        }

        //get all cars
        [HttpGet]
        [Route("getallcars")]
        public async Task<IActionResult> getallcars()
        {

            try
            {
                var listcar =   _context.Cars.Select(c => new
                {
                    
                    c.CrId,
                    c.CrName,
                    c.CrType,
                    c.CrDescription,
                    c.CrPaper1,
                    c.CrPaper2,
                    c.CrRegPlate,
                    c.CrModel,
                    drivername =  c.DIdNavigation.DName,
                    drivesurname = c.DIdNavigation.DSurname,
                    driveemail= c.DIdNavigation.DEmail,
                    drivenumber = c.DIdNavigation.DPhone,

                }).ToList();


                if(listcar != null)
                {
                    return Ok(listcar);
                }

                return BadRequest("The are no cars here");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all cars not verified
        [HttpGet]
        [Route("carsnotve")]
        public async Task<IActionResult> carsnotver()
        {
            try
            {
                var listcar = _context.Cars.Select(c => new
                {

                    c.CrId,
                    c.CrName,
                    c.CrType,
                    c.CrDescription,
                    c.CrPaper1,
                    c.CrPaper2,
                    c.CrRegPlate,
                    c.CrModel,
                    drivername = c.DIdNavigation.DName,
                    drivesurname = c.DIdNavigation.DSurname,
                    driveemail = c.DIdNavigation.DEmail,
                    drivenumber = c.DIdNavigation.DPhone,

                }).Where(dd => dd.CrPaper2 == "NotVerified").ToList();


                if (listcar != null)
                {
                    return Ok(listcar);
                }

                return BadRequest("The are no cars here");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all cars that are available
        [HttpGet]
        [Route("carsavail")]
        public async Task<IActionResult> carsava()
        {
            try
            {
                var listcar = _context.Cars.Select(c => new
                {

                    c.CrId,
                    c.CrName,
                    c.CrType,
                    c.CrDescription,
                    c.CrPaper1,
                    c.CrPaper2,
                    c.CrRegPlate,
                    c.CrModel,
                    drivername = c.DIdNavigation.DName,
                    drivesurname = c.DIdNavigation.DSurname,
                    driveemail = c.DIdNavigation.DEmail,
                    drivenumber = c.DIdNavigation.DPhone,

                }).Where(dd => dd.CrDescription == "Available").ToList();


                if (listcar != null)
                {
                    return Ok(listcar);
                }

                return BadRequest("The are no cars here");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //Update car Status by admin and the email sending
        [HttpPut]
        [Route("upcarstatus/{id}")]
        public async Task<ActionResult> memberrupdate([FromBody] UpdateCarStats user, int id)
        {

            try
            {


                var dbu = _context.Cars.Where(u => u.CrId == id).FirstOrDefault<Car>();

             
                if (dbu == null)
                {
                    return BadRequest("car not found");
                }

                //verification
                dbu.CrPaper2 = user.CrPaper2;
                
                await _context.SaveChangesAsync();

                return Ok(new { message = "car status successful updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //Update car Status of availbale by the driver
        [HttpPut]
        [Route("upcaravail/{id}")]
        public async Task<ActionResult> avaicar([FromBody] CarAvail user, int id)
        {
           


            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("DriverID"));

                var dbu = _context.Cars.Where(u => u.CrId == id && u.DId == userID).FirstOrDefault<Car>();

                if (userID == null || userID <= 0)
                {
                    return BadRequest("Yuu are not log in");
                }
                if (dbu == null)
                {
                    return BadRequest("car not found");
                }

                //verification
                dbu.CrDescription = user.CrDescription;

                await _context.SaveChangesAsync();

                return Ok(new { message = "car status successful of availablity updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update car papers by the driver
        [HttpPut]
        [Route("upcarpapers/{id}")]
        public async Task<ActionResult> carpapers([FromForm] CarPapers user, int id, IFormFile pdfFile)
        {
            


            try
            {

                var fiveMegaByte = 5 * 1024 * 1024;
                var pdfMimeType = "application/pdf";

                if (pdfFile.Length > fiveMegaByte || pdfFile.ContentType != pdfMimeType)
                {
                    return BadRequest("file n t v");
                }

                var urlpdf = Guid.NewGuid().ToString() + ".pdf";
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "cars", urlpdf);

                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await pdfFile.CopyToAsync(stream);

                }



                 int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("DriverID"));
                var dbu = _context.Cars.Where(u => u.CrId == id && u.DId == userID).FirstOrDefault<Car>();

                if (userID == null || userID <= 0)
                {
                    return BadRequest("Yuu are not log in");
                }
                if (dbu == null)
                {
                    return BadRequest("car not found");
                }



                //verification
                dbu.CrPaper1 = urlpdf;

                await _context.SaveChangesAsync();

                return Ok(new { message = "car papers updated succesful" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get a sigle car 
        [HttpGet]
        [Route("getsingcar/{id}")]
        public async Task<IActionResult> getsingcar(int id)
        {


            try
            {
             
                if (id == null || id <= 0)
                {
                    return BadRequest("This booking is not available");
                }

                var booklist = _context.Cars.Select(c => new
                {
                    c.CrId,
                    c.CrName,
                    c.CrType,
                    c.CrDescription,
                    c.CrPaper1,
                    c.CrPaper2,
                    c.CrRegPlate,
                    c.CrModel,
                    c.DId,
                    drivername = c.DIdNavigation.DName,
                    drivesurname = c.DIdNavigation.DSurname,
                    driveemail = c.DIdNavigation.DEmail,
                    drivenumber = c.DIdNavigation.DPhone,
                }).Where(t => t.CrId == id).FirstOrDefault();

                return Ok(booklist);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get single car by the driver

        [HttpGet]
        [Route("getsingcardriv/{id}")]
        public async Task<IActionResult> getsingcardr(int id)
        {


            try
            {
                int userID = Convert.ToInt32(HttpContext.User.FindFirstValue("DriverID"));



                if (userID == null || userID <= 0)
                {
                    return BadRequest("Please log in !! Cant book");
                }
                if (id == null || id <= 0)
                {
                    return BadRequest("This booking is not available");
                }

                var booklist = _context.Cars.Select(c => new
                {
                    c.CrId,
                    c.CrName,
                    c.CrType,
                    c.CrDescription,
                    c.CrPaper1,
                    c.CrPaper2,
                    c.CrRegPlate,
                    c.CrModel,
                    c.DId,
                    drivername = c.DIdNavigation.DName,
                    drivesurname = c.DIdNavigation.DSurname,
                    driveemail = c.DIdNavigation.DEmail,
                    drivenumber = c.DIdNavigation.DPhone,
                }).Where(t => t.DId == userID && t.CrId == id).FirstOrDefault();

                return Ok(booklist);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
