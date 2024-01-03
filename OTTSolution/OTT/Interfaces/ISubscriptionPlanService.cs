using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface ISubscriptionPlanService
    {
        public SubscriptionPlanDTO Add(SubscriptionPlanDTO subscriptionPlanDTO);

        public SubscriptionPlanDTO Update(int id,SubscriptionPlanDTO subscriptionPlanDTO);

        public bool Delete(int id);

        public List<SubscriptionPlan> GetAll();
    }
}
