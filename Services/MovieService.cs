using Microsoft.EntityFrameworkCore;
using WebServicesNenadExam5063.Models;
using WebServicesNenadExam5063.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServicesNenadExam5063.Services
{
    public class MovieService : IMovieInterface
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movie.FindAsync(id);
        }

        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovieAsync(int id, Movie movie)
        {
            var existingMovie = await _context.Movie.FindAsync(id);
            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Genre = movie.Genre;
                existingMovie.Director = movie.Director;
                await _context.SaveChangesAsync();
            }
            return existingMovie;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
