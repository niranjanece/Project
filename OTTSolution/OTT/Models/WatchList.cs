using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTT.Models
{
    public class WatchList
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        [ForeignKey("Email")]
        public User user { get; set; }

        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie movie { get; set; }
    }
}
