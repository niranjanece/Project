using System.ComponentModel.DataAnnotations;

namespace OTT.Models
{
    public class SubscriptionPlan
    {
        [Key]
        public int PlanId { get; set; }
        public int Month { get; set; }

        public float Price { get; set; }
    }
}
