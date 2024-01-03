using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTT.Interfaces;
using OTT.Models.DTOs;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchHistoryController : ControllerBase
    {
        private readonly IWatchHistoryService _service;

        public WatchHistoryController(IWatchHistoryService service)
        {
            _service = service;
        }

        [HttpPost("AddHistory")]
        public ActionResult AddHistory(WatchHistoryDTO watchHistortDTO)
        {
            var history = _service.AddHistory(watchHistortDTO);
            if (history != null)
            {
                return Ok(history);
            }
            return BadRequest("Could not add history");
        }

        [HttpGet("GetHistory")]
        public ActionResult GetHistory(string Email)
        {
            var history = _service.GetHistory(Email);
            if (history != null)
            {
                return Ok(history);
            }
            return BadRequest("No history yet");
        }

        [HttpDelete("RemoveHistory")]
        public ActionResult DeleteHistory(int id)
        {
            var result = _service.RemoveHistory(id);
            if (result)
            {
                return Ok("Deleted Sucessfully");
            }
            return BadRequest("Could not delete");
        }
    }
}
