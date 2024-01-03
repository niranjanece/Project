using System.ComponentModel.DataAnnotations.Schema;

namespace OTT.Models.DTOs
{
    public class UserSubscriptionDTO
    {
        public string Email { get; set; }
     
        public int PlanId { get; set; }
      
 
    }
}
