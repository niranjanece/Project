using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTT.Interfaces;
using OTT.Models.DTOs;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionPlanController : ControllerBase
    {
        private readonly ISubscriptionPlanService _service;

        public SubscriptionPlanController(ISubscriptionPlanService service)
        {
            _service = service; 
        }
        [HttpPost("Add")]
        public ActionResult AddPlan(SubscriptionPlanDTO subscriptionPlanDTO) 
        {
            var result = _service.Add(subscriptionPlanDTO);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not add");
        }

        [HttpGet("Get")]
        public ActionResult GetAllPlan()
        {
            var result = _service.GetAll();
            if(result != null)
            {
                return Ok(result);
            }
            return null;
        }

        [HttpDelete("Delete")]
        public ActionResult DeletePlan(int id)
        {
            var result = _service.Delete(id);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not delete");
        }

        [HttpPut("Update")]
        public ActionResult UpdatePlan(int id,SubscriptionPlanDTO subscriptionPlanDTO)
        {
            var result = _service.Update(id,subscriptionPlanDTO);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not update");
        }
    }
}
