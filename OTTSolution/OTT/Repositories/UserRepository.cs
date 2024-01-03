using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        private readonly OTTContext _context;

        public UserRepository(OTTContext context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string id)
        {
           var user = GetById(id);
            if(user != null)
            {
                _context.Users.Remove(user);  
                _context.SaveChanges();
                return user;
            }
            return null;
        }

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null;
            return _context.Users.ToList();
        }

        public User GetById(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == id);
            return user;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.Email);
            if(user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }
}
