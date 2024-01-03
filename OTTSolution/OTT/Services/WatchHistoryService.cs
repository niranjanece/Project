using Microsoft.EntityFrameworkCore.ChangeTracking;
using OTT.Interfaces;
using OTT.Models;
using OTT.Models.DTOs;
using OTT.Repositories;

namespace OTT.Services
{
    public class WatchHistoryService : IWatchHistoryService
    {
        private readonly IRepository<int, WatchHistory> _repository;
        private readonly IRepository<int, Movie> _movieRepository;

        public WatchHistoryService(IRepository<int, WatchHistory> repository, IRepository<int, Movie> movieRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
        }
        public WatchHistoryDTO AddHistory(WatchHistoryDTO histortDTO)
        {
            WatchHistory history = new WatchHistory()
            {
                Email = histortDTO.Email,
                MovieId = histortDTO.MovieId,
                Details = histortDTO.Details
            };
            var result = _repository.Add(history);
            if(result != null)
            {
                return histortDTO;
            }
            return null;
        }

        public List<WatchHistoryDisplayDTO> GetHistory(string email)
        {
            var history = _repository.GetAll().Where(h => h.Email == email).ToList();
            List<WatchHistoryDisplayDTO> watchHistories = new List<WatchHistoryDisplayDTO>();
            foreach (var item in history)
            {
                var movie = _movieRepository.GetById(item.MovieId);
                WatchHistoryDisplayDTO dto = new WatchHistoryDisplayDTO()
                {
                    watchHistoryId = item.WatchHistoryId,
                    Email = item.Email,
                    movieId = item.MovieId,
                    details = item.Details,
                    Title = movie.Title,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    Language = movie.Language,
                    Genres = movie.Genres,
                    Rating = movie.Rating,
                    Duration = movie.Duration,
                    Enable = movie.Enable
                };
                watchHistories.Add(dto);
            }
            if (history != null)
            {
                return watchHistories;
            }
            return null;
        }

        public bool RemoveHistory(int id)
        {
            var result = _repository.Delete(id);    
            if(result != null)
            {
                return true;
            }
            return false;
        }
    }
}
    