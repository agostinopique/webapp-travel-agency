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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PacchettoViaggio packDetail = _db.PacchettoViaggio.Find(id);

            if(packDetail == null)
            {
                return NotFound();
            } 
            else
            {
                return Ok(packDetail);
            }
        }
    }
}
