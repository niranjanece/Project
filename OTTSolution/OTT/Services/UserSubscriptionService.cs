using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;
using System.Numerics;

namespace OTT.Services
{
    public class UserSubscriptionService : IUserSubscriptionService
    {
        private readonly IRepository<string, UserSubscription> _repository;
        private readonly IRepository<int, SubscriptionPlan> _subscriptionPlanRepository;

        public UserSubscriptionService(IRepository<string, UserSubscription> repository, IRepository<int,SubscriptionPlan> subscriptionPlanRepository)
        {
            _repository = repository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
        }
        public UserSubscriptionDTO AddSubscription(UserSubscriptionDTO subscription)
        {
            DateTime date = DateTime.Today;
            if(subscription != null)
            {
                var month = _subscriptionPlanRepository.GetAll().SingleOrDefault(m => m.PlanId == subscription.PlanId);
                if(month != null)
                {
                    UserSubscription userSubscription = new UserSubscription()
                    {
                        Email = subscription.Email,
                        PlanId = subscription.PlanId,
                        StartDate = date.ToString(),
                        EndDate = date.AddMonths(month.Month).ToString()
                    };
                    var result = _repository.Add(userSubscription);
                    if (result != null)
                    {
                        return subscription;
                    }
                }
            }
            return null;
        }

        public List<UserSubscription> GetSubscription()
        {
            var result = _repository.GetAll();
            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }

        public bool RemoveSubscription(string id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public UserSubscriptionDTO UpdateSubscription(string id,UserSubscriptionDTO subscription)
        {
            var plan = _repository.GetById(id);
            if (plan != null)
            {
                plan.Email = subscription.Email;
                plan.PlanId = subscription.PlanId;
            }
            var result = _repository.Update(plan);
            if (result != null)
            {
                return subscription;
            }
            return null;
        }
    }
}
