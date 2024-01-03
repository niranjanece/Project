using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class WatchHistoryRepository : IRepository<int, WatchHistory>
    {
        private readonly OTTContext _context;

        public WatchHistoryRepository(OTTContext context)
        {
            _context = context;
        }
        public WatchHistory Add(WatchHistory entity)
        {
            _context.WatchHistories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public WatchHistory Delete(int id)
        {
            var watch = GetById(id);
            if (watch != null)
            {
                _context.WatchHistories.Remove(watch);
                _context.SaveChanges();
                return watch;
            }
            return null;
        }

        public IList<WatchHistory> GetAll()
        {
            if (_context.WatchHistories.Count() == 0)
                return null;
            return _context.WatchHistories.ToList();
        }

        public WatchHistory GetById(int id)
        {
            var watch = _context.WatchHistories.SingleOrDefault(u => u.WatchHistoryId == id);
            return watch;
        }

        public WatchHistory Update(WatchHistory entity)
        {
            var watch = GetById(entity.WatchHistoryId);
            if (watch != null)
            {
                _context.Entry<WatchHistory>(watch).State = EntityState.Modified;
                _context.SaveChanges();
                return watch;
            }
            return null;
        }
    }
}
