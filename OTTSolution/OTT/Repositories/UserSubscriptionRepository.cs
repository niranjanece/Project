using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class UserSubscriptionRepository : IRepository<string, UserSubscription>
    {
        private readonly OTTContext _context;

        public UserSubscriptionRepository(OTTContext context)
        {
            _context = context;
        }
        public UserSubscription Add(UserSubscription entity)
        {
            _context.UserSubscriptions.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public UserSubscription Delete(string id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.UserSubscriptions.Remove(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<UserSubscription> GetAll()
        {
            if (_context.UserSubscriptions.Count() == 0)
                return null;
            return _context.UserSubscriptions.ToList();
        }

        public UserSubscription GetById(string id)
        {
            var user = _context.UserSubscriptions.SingleOrDefault(u => u.Email == id);
            return user;
        }

        public UserSubscription Update(UserSubscription entity)
        {
            var user = GetById(entity.Email);
            if (user != null)
            {
                _context.Entry<UserSubscription>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }
}
