using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Services
{
    public class SubscriptionPlanService : ISubscriptionPlanService
    {
        private readonly IRepository<int, SubscriptionPlan> _repository;

        public SubscriptionPlanService(IRepository<int,SubscriptionPlan> repository)
        {
            _repository = repository;
        }
        public SubscriptionPlanDTO Add(SubscriptionPlanDTO subscriptionPlanDTO)
        {
            SubscriptionPlan subscriptionPlan = new SubscriptionPlan()
            {
                Month = subscriptionPlanDTO.Month,
                Price = subscriptionPlanDTO.Price
            };
            var result = _repository.Add(subscriptionPlan);
            if(result != null)
            {
                return subscriptionPlanDTO;
            }
            return null;
        }

        public bool Delete(int id)
        {
            var result = _repository.Delete(id);
            if(result != null)
            {
                return true;
            }
            return false;
        }

        public List<SubscriptionPlan> GetAll()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }

        public SubscriptionPlanDTO Update(int id, SubscriptionPlanDTO subscriptionPlanDTO)
        {
            var plan = _repository.GetById(id);
            if(plan != null)
            {
                plan.Price = subscriptionPlanDTO.Price;
                plan.Month = subscriptionPlanDTO.Month;
            }
            var result = _repository.Update(plan);
            if(result != null)
            {
                return subscriptionPlanDTO;
            }
            return null;
        }
    }
}
