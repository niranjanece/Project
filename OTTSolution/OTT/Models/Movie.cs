using System.ComponentModel.DataAnnotations;

namespace OTT.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public string Language { get; set; }
        public string Genres { get; set; }
        public float Rating { get; set; }
        public string Duration { get; set; }
        public string Enable { get; set; }
    }
}
