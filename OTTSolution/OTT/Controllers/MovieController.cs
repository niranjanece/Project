using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTT.Interfaces;
using OTT.Models.DTOs;

namespace OTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("Add")]
        public ActionResult AddMovie(MovieDTO movieDTO)
        {
            var movie = _movieService.AddMovie(movieDTO);
            if(movie != null)
            {
                return Ok(movie);
            }
            return BadRequest("Could not add movie");
        }

        [HttpGet("GetMovies")]
        public ActionResult GetMovies()
        {
            var movies = _movieService.GetAll();
            if(movies != null)
            {
                return Ok(movies);
            }
            return BadRequest("No movies available");
        }

        [HttpGet("GetMoviesGenre")]
        public ActionResult GetMoviesGenre(string genre)
        {
            var movies = _movieService.GetMoviesByGenre(genre);
            if (movies != null)
            {
                return Ok(movies);
            }
            return BadRequest("No movies available");
        }

        [HttpDelete("Delete")]
        public ActionResult DeleteMovie(int id)
        {
            var result = _movieService.Delete(id);
            if(result != false)
                return Ok("Deleted Sucessfully");
            return BadRequest("Could not delete");
        }

        [HttpPut("Update")]
        public ActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {
            var movie = _movieService.Update(id,movieDTO);
            if (movie != null)
            {
                return Ok(movie);
            }
            return BadRequest("Could not add movie");
        }
    }
}
