using Microsoft.EntityFrameworkCore;
using WebServicesNenadExam5063.Models;
using WebServicesNenadExam5063.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebServicesNenadExam5063.Services
{
    public class ClientService : IClientInterface
    {
        private readonly AppDbContext _context;

        public ClientService(AppDbContext context)  
        {
            _context = context;
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Client.FindAsync(id);
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            var existingClient = await _context.Client.FindAsync(id);
            if (existingClient != null)
            {
                existingClient.First_Name = client.First_Name;
                existingClient.Last_Name = client.Last_Name;
                // The other properties that can be modified should be here
                await _context.SaveChangesAsync();
            }
            return existingClient;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Client> RentAMovie(int ClientId, int MovieId)
        {
            var existingClient = await _context.Client.FindAsync(ClientId);
            if (existingClient != null)
            {
                existingClient.MovieId = MovieId;
                await _context.SaveChangesAsync();
            }
            return existingClient;
        }
    }
}
