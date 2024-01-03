using Microsoft.EntityFrameworkCore;
using OTT.Models;

namespace OTT.Context
{
    public class OTTContext : DbContext
    {
        public OTTContext(DbContextOptions option) : base(option)
        { 
        
        }
        public DbSet<User> Users{ get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

        public DbSet<WatchHistory> WatchHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSubscription>(sub =>
            {
                sub.HasKey(subk => new { subk.Email, subk.PlanId });
            });

            //modelBuilder.Entity<WatchHistory>(l =>
            //{
            //    l.HasKey(l => new { l.Email, l.Details });
            //});
        }
    }
}
