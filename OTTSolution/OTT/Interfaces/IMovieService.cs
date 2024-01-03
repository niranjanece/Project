using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface IMovieService
    {
        public MovieDTO AddMovie(MovieDTO movie);

        public bool Delete(int id);

        public List<Movie> GetAll();

        public List<Movie> GetMoviesByGenre(string genre);

        public MovieDTO Update(int id,MovieDTO movie);
    }
}
