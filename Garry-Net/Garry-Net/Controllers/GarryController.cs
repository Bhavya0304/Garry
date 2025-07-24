using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Garry_Net.Controllers
{
    [ApiController]
    [Route("api")]
    public class GarryController : ControllerBase
    {
        private readonly IConfiguration _config;

        public GarryController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("join")]
        public async Task<IActionResult> JoinMeeting()
        {
            
            var garry = new GarryMeetingJoiner(_config);
            await garry.RunAsync();
            return Ok(new { message = "Garry has joined the meeting." });
        }
    }
}
