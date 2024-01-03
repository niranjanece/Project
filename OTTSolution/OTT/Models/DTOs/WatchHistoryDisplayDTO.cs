namespace OTT.Models.DTOs
{
    public class WatchHistoryDisplayDTO
    {
        public int watchHistoryId { get; set; }
        public string Email { get; set; }
        public int movieId { get; set; }
        public string details { get; set; }
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
