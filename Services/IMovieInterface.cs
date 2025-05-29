using WebServicesNenadExam5063.Models;

namespace WebServicesNenadExam5063.Services
{
    public interface IMovieInterface
    {
        Task<List<Movie>>GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task<Movie> UpdateMovieAsync(int Id, Movie movie);
        Task<bool> DeleteMovieAsync(int Id);
    }
}
