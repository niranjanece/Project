using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTT.Interfaces;
using OTT.Models.DTOs;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSubscriptionController : ControllerBase
    {
        private readonly IUserSubscriptionService _service;

        public UserSubscriptionController(IUserSubscriptionService service)
        {
            _service = service;
        }
        [HttpPost("Add")]
        public ActionResult AddPlan(UserSubscriptionDTO subscriptionPlanDTO)
        {
            var result = _service.AddSubscription(subscriptionPlanDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not add");
        }

        [HttpGet("Get")]
        public ActionResult GetAllPlan()
        {
            var result = _service.GetSubscription();
            if (result != null)
            {
                return Ok(result);
            }
            return null;
        }

        [HttpDelete("Delete")]
        public ActionResult DeletePlan(string id)
        {
            var result = _service.RemoveSubscription(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not delete");
        }

        [HttpPut("Update")]
        public ActionResult UpdatePlan(string id, UserSubscriptionDTO subscriptionPlanDTO)
        {
            var result = _service.UpdateSubscription(id, subscriptionPlanDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Could not update");
        }
    }
}
