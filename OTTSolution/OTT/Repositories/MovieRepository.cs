using Microsoft.EntityFrameworkCore;
using OTT.Context;
using OTT.Interfaces;
using OTT.Models;

namespace OTT.Repositories
{
    public class MovieRepository : IRepository<int, Movie>
    {
        private readonly OTTContext _context;

        public MovieRepository(OTTContext context)
        {
            _context = context;
        }
        public Movie Add(Movie entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Movie Delete(int id)
        {
            var movie = GetById(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return movie;
            }
            return null;
        }

        public IList<Movie> GetAll()
        {
            if (_context.Movies.Count() == 0)
                return null;
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);
            return movie;
        }

        public Movie Update(Movie entity)
        {
            var movie = GetById(entity.MovieId);
            if (movie != null)
            {
                _context.Entry<Movie>(movie).State = EntityState.Modified;
                _context.SaveChanges();
                return movie;
            }
            return null;
        }
    }
}
