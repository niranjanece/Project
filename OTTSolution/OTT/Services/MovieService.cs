using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Services
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<int, Movie> _repository;

        public MovieService(IRepository<int, Movie> repository)
        {
            _repository = repository;
        }
        public MovieDTO AddMovie(MovieDTO movie)
        {
           Movie movie1 = new Movie()
           {
               Title = movie.Title,
               Description = movie.Description,
               ReleaseDate = movie.ReleaseDate,
               Genres = movie.Genres,
               Rating = movie.Rating,
               Duration = movie.Duration,
               Enable = movie.Enable,
               Language = movie.Language
           };
            var result = _repository.Add(movie1);
            if(result != null)
            {
                return movie;
            }
            return null;
        }

        public bool Delete(int id)
        {
             var movie = _repository.Delete(id);
             if (movie != null)
                 return true;
             return false;
        }

        public List<Movie> GetAll()
        {
            var result = _repository.GetAll();
            if(result != null)
            {
                return result.ToList();
            }
            return null;
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            var result = _repository.GetAll().Where(m => m.Genres == genre).ToList();
            if(result.Count > 0)
                return result;
            return null;
        }

        public MovieDTO Update(int id,MovieDTO movie)
        {
            var res = _repository.GetById(id);
            if(res != null) 
            {
                res.Title = movie.Title;
                res.Description = movie.Description;
                res.ReleaseDate = movie.ReleaseDate;
                res.Genres = movie.Genres;
                res.Rating = movie.Rating;
                res.Duration = movie.Duration;
                res.Enable = movie.Enable;
                res.Language = movie.Language;
            }
            var result = _repository.Update(res);
            if(result != null)
            {
                return movie;
            }
            return null;
        }
    }
}
