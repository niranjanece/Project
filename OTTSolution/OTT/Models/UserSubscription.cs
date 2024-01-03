using System.ComponentModel.DataAnnotations.Schema;

namespace OTT.Models
{
    public class UserSubscription
    {
        public string Email { get; set; }
        [ForeignKey("Email")]
        public User user { get; set; }

        public int PlanId { get; set; }
        [ForeignKey("PlanId")]
        public SubscriptionPlan subscription { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
