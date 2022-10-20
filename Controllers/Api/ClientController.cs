using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private TravelContext _db;
        public ClientController()
        {
            _db = new TravelContext();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<PacchettoViaggio> packages = _db.PacchettoViaggio.ToList();    
            return Ok(packages);
        }
    }
}
