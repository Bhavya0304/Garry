using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Garry_Net.Controllers
{
    [ApiController]
    [Route("api")]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _logger;

        public CallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }

        [HttpPost("callback")]
        public async Task<IActionResult> OnCallback()
        {
            // Log request for now
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();

            _logger.LogInformation("Callback received:\n{0}", body);

            // Respond with 200 OK
            return Ok();
        }
    }
}
