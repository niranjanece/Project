using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class SubscriptionPlanRepository : IRepository<int, SubscriptionPlan>
    {
        private readonly OTTContext _context;

        public SubscriptionPlanRepository(OTTContext context)
        {
            _context = context;
        }
        public SubscriptionPlan Add(SubscriptionPlan entity)
        {
            _context.SubscriptionPlans.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public SubscriptionPlan Delete(int id)
        {
            var plan = GetById(id);
            if (plan != null)
            {
                _context.SubscriptionPlans.Remove(plan);
                _context.SaveChanges();
                return plan;
            }
            return null;
        }

        public IList<SubscriptionPlan> GetAll()
        {
            if (_context.SubscriptionPlans.Count() == 0)
                return null;
            return _context.SubscriptionPlans.ToList();
        }

        public SubscriptionPlan GetById(int id)
        {
            var plan = _context.SubscriptionPlans.SingleOrDefault(p => p.PlanId == id);
            return plan;
        }

        public SubscriptionPlan Update(SubscriptionPlan entity)
        {
            var plan = GetById(entity.PlanId);
            if (plan != null)
            {
                _context.Entry<SubscriptionPlan>(plan).State = EntityState.Modified;
                _context.SaveChanges();
                return plan;
            }
            return null;
        }
    }
}
