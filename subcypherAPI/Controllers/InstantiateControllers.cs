using Microsoft.AspNetCore.Mvc;
using subcypherAPI.Models;

namespace subcypherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstantiateControllers : ControllerBase
    {
        // GET: api/<InstantiateControllers>
        [HttpPost("instantiate")]
        public ActionResult<int> InstantiateModel([FromBody] InstantiateModel InstantiateModel)
        {
            try
            {
                int jumps = InstantiateModel.Jumps;
                return jumps;
            }
            catch (FormatException)
            {
                return BadRequest("Error! Please enter a number between 1-26");
            }
        }
    }
}
