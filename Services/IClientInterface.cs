using WebServicesNenadExam5063.Models;

namespace WebServicesNenadExam5063.Services
{
    public interface IClientInterface
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> GetClientByIdAsync(int Id);
        Task<Client> AddClientAsync(Client client);
        Task<Client> UpdateClientAsync(int Id, Client client);
        Task<bool> DeleteClientAsync(int Id);
        Task<Client> RentAMovie(int ClientId, int MovieId);

    }
}
