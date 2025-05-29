using Microsoft.AspNetCore.Mvc;
using WebServicesNenadExam5063.Models;
using WebServicesNenadExam5063.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServicesNenadExam5063.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieInterface _movieService;

        
        public MovieController(IMovieInterface movieService)
        {
            _movieService = movieService;
        }

        // GET: api/movie
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);  
        }

        // GET: api/movie/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();  
            }
            return Ok(movie);  
        }

        // POST: api/movie
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie cannot be null");  
            }

            var addedMovie = await _movieService.AddMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = addedMovie.Id }, addedMovie);  
        }

        // PUT: api/movie/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest("Movie cannot be null");  
            }

            var updatedMovie = await _movieService.UpdateMovieAsync(id, movie);
            if (updatedMovie == null)
            {
                return NotFound();  
            }

            return Ok(updatedMovie);  
        }

        // DELETE: api/movie/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);
            if (result)
            {
                return NoContent();  
            }
            return NotFound(); 
        }
    }
}
