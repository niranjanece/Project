using System.ComponentModel.DataAnnotations.Schema;

namespace OTT.Models.DTOs
{
    public class WatchHistoryDTO
    {
       
        public string Email { get; set; }
        public string Details { get; set; }
        public int MovieId { get; set; }
    }
}
