using CodeChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Data;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger<CompensationController> _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        // create compensation given employeeId
        [HttpPost("{id}")]
        public ActionResult<Compensation> CreateCompensationById(string id, [FromBody] Compensation compensation)
        {
            _logger.LogDebug("Received compensation create request for employeeID {Id}", id);
            //needs to create new compensation object
            var createdCompensation = _compensationService.Create(compensation);
            return CreatedAtAction(nameof(ReadCompensationById), new { id = createdCompensation.employeeId }, createdCompensation);
        }

        // read compensation given employeeId
        [HttpGet("{id}")]
        public ActionResult<Compensation> ReadCompensationById(string id)
        {
            _logger.LogDebug("Received compensation get request for employeeID [{Id}]", id);

            var compensation = _compensationService.Read(id);
            if (compensation == null)
            {
                return NotFound();
            }

            return compensation;
        }
    }
}

