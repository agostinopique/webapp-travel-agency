using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] Message messageData)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            TravelContext context = new TravelContext();
            context.Message.Add(messageData);
            context.SaveChanges();
            return Ok();
        }
    }
}
