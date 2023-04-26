using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VG_TransportAPI.Interfaces;
using VG_TransportAPI.Models;

namespace VG_TransportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {

        private readonly VgtransportContext _context;

        private readonly IConfiguration _configuration;

        private readonly IEMailServices _emailServices;

        public DriverStorageController(VgtransportContext _context, IConfiguration _configuration, IEMailServices emailServices)
        {
            this._context = _context;
            this._configuration = _configuration;
            _emailServices = emailServices;
        }
    }
}
