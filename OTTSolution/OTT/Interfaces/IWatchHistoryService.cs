using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface IWatchHistoryService
    {
        public WatchHistoryDTO AddHistory(WatchHistoryDTO histortDTO);

        public bool RemoveHistory(int id);

        public List<WatchHistoryDisplayDTO> GetHistory(string email);
    }
}
