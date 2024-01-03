using OTT.Models;
using OTT.Models.DTOs;

namespace OTT.Interfaces
{
    public interface IWatchListService
    {
        public WatchListDTO AddList(WatchListDTO dto);

        public bool RemoveList(int id);
        public List<WatchListDisplayDTO> GetList(string Email);
    }
}
