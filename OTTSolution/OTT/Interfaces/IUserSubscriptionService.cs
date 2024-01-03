using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface IUserSubscriptionService
    {
        public UserSubscriptionDTO AddSubscription(UserSubscriptionDTO subscription);

        public bool RemoveSubscription(string id);

        public List<UserSubscription> GetSubscription();

        public UserSubscriptionDTO UpdateSubscription(string id, UserSubscriptionDTO subscription);
    }
}
