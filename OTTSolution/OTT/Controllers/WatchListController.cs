using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OTT.Interfaces;
using OTT.Models.DTOs;
using OTT.Services;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListService _service;

        public WatchListController(IWatchListService service)
        {
            _service = service;
        }
        [HttpPost("AddList")]
        public ActionResult AddList(WatchListDTO watchListDTO)
        {
            var list = _service.AddList(watchListDTO);
            if (list != null)
            {
                return Ok(list);
            }
            return BadRequest("Could not add list");
        }

        [HttpGet("GetList")]
        public ActionResult GetList(string Email)
        {
            var list = _service.GetList(Email);
            if(list != null)
            {
                return Ok(list);
            }
            return BadRequest("Could not get the list");
        }
        [HttpDelete("RemoveList")]
        public ActionResult RemoveList(int id)
        {
            var result = _service.RemoveList(id);
            if (result)
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Could not delete");
        }
    }
}
