using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServicesNenadExam5063.Models;
using WebServicesNenadExam5063.Services;

namespace WebServicesNenadExam5063.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientInterface _clientService;

        public ClientController(IClientInterface clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            var clients = await _clientService.GetClientsAsync();
            return Ok(clients);
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        // POST: api/Client
        [HttpPost]
        public async Task<ActionResult<Client>> AddClient(Client client)
        {
            var createdClient = await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = createdClient.Id }, createdClient);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> UpdateClient(int id, Client client)
        {
            var updatedClient = await _clientService.UpdateClientAsync(id, client);
            if (updatedClient == null)
            {
                return NotFound();
            }
            return Ok(updatedClient);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Client/RentAMovie
        [HttpPost("RentAMovie")]
        public async Task<ActionResult<Client>> RentAMovie(int clientId, int movieId)
        {
            var client = await _clientService.RentAMovie(clientId, movieId);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
