using hss_api.Models;
using hss_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace hss_api.Controllers
{
    [Route("[controller]")]
    public class SpotController : Controller
    {
        private ISpotService spotService;

        public SpotController(ISpotService spotService)
        {
            this.spotService = spotService;
        }

        /*
         * GET endpoints
         */

        // Get by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var spot = this.spotService.GetSpotById(id);
            if (spot == null)
            {
                return NotFound();
            }

            return Ok(spot);
        }

        // Get all
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var spots = this.spotService.GetAllSpots();
            if (spots.Count == 0)
            {
                return NoContent();
            }

            return Ok(spots);
        }


        /*
         *  POST endpoints
         */

        // Post
        [HttpPost()]
        public IActionResult Post([FromBody] Spot spot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.spotService.AddSpot(spot);

            return Ok("Added spot");
        }
    }
}
