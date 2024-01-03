using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly IRepository<int, WatchList> _repository;
        private readonly IRepository<int, Movie> _movieRepository;

        public WatchListService(IRepository<int,WatchList> repository, IRepository<int,Movie> movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
        }
        public WatchListDTO AddList(WatchListDTO dto)
        {
            WatchList list = new WatchList()
            {
                Email = dto.Email,
                MovieId = dto.MovieId
            };
            var result = _repository.Add(list);
            if(result != null)
            {
                return dto;
            }
            return null;
        }

        public List<WatchListDisplayDTO> GetList(string Email)
        {
            var result = _repository.GetAll().Where(l => l.Email==Email).ToList();
            List<WatchListDisplayDTO> watchLists = new List<WatchListDisplayDTO>();
            foreach(var item in result)
            {
                var movie = _movieRepository.GetById(item.MovieId);
                WatchListDisplayDTO dto = new WatchListDisplayDTO()
                {
                    Id = item.Id,
                    Email=item.Email,
                    MovieId=item.MovieId,
                    Title = movie.Title,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    Language = movie.Language,
                    Genres = movie.Genres,
                    Rating = movie.Rating,
                    Duration = movie.Duration,
                    Enable = movie.Enable
                };
                watchLists.Add(dto);
            }
            if (result != null)
            {
                return watchLists;
            }
            return null;
        }

        public bool RemoveList(int id)
        {
            var result = _repository.Delete(id);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
