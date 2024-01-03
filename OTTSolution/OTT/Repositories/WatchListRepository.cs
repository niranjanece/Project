using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class WatchListRepository : IRepository<int, WatchList>
    {
        private readonly OTTContext _context;

        public WatchListRepository(OTTContext context)
        {
            _context = context;
        }
        public WatchList Add(WatchList entity)
        {
            _context.WatchLists.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public WatchList Delete(int id)
        {
            var list = GetById(id);
            if (list != null)
            {
                _context.WatchLists.Remove(list);
                _context.SaveChanges();
                return list;
            }
            return null;
        }

        public IList<WatchList> GetAll()
        {
            if (_context.WatchLists.Count() == 0)
                return null;
            return _context.WatchLists.ToList();
        }

        public WatchList GetById(int id)
        {
            var list = _context.WatchLists.SingleOrDefault(w => w.Id == id);
            return list;
        }

        public WatchList Update(WatchList entity)
        {
            var list = GetById(entity.Id);
            if (list != null)
            {
                _context.Entry<WatchList>(list).State = EntityState.Modified;
                _context.SaveChanges();
                return list;
            }
            return null;
        }
    }
}
