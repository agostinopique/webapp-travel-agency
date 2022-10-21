using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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

        [HttpGet]
        public IActionResult GetPack(string? param)
        {
            if(param == null)
            {
                return BadRequest();
            }

            List<PacchettoViaggio> packs = _db.PacchettoViaggio.Where(pack => pack.Name.ToLower().Contains(param.ToLower()) || pack.Description.ToLower().Contains(param.ToLower())).ToList();

            return Ok(packs);
        }
    }
}
