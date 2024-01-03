using OTT.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTT.Interfaces
{
    public class WatchListDTO
    {
        public string Email { get; set; }
        public int MovieId { get; set; }
    }
}
