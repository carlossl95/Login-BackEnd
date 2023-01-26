using Microsoft.AspNetCore.Mvc;
using Serve.Domain;
using Serve.Domain.IRepository;
using Serve.Domain.Service;
using Serve.Infra.Data.Repository;

namespace Serve.WebApi.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;
        private readonly IClientRepository _clientRepository;

        public ClientController()
        {
            _clientRepository = new ClientRepository();
            _clientService = new ClientService(_clientRepository);
        }

        [HttpPost ("login")]
        public IActionResult GetLogin(Client loginClient)
        {
            try
            {
                return Ok(_clientService.Login(loginClient));
            }
            catch (Exception e)
            {
                return StatusCode(500, new Resposta(500, e.Message));
            }
        }

        [HttpPost]
        public IActionResult PostNewClient(Client newClient)
        {
            try
            {
                return Ok(_clientService.AddNewClient(newClient));
            }
            catch (Exception e)
            {                
                return StatusCode(500, new Resposta(500, e.Message));
            }
            
        }       

        [HttpGet("ID/{id}")]
        public IActionResult Teste(int id)
        {
            try
            {
                return Ok(_clientService.SearchClient(id));
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new Resposta(500, e.Message));
            }
        }

        [HttpHead("id/{id}/currentPassword/{currentPassword}/newPassword/{newPassword}")]
        public IActionResult EditPassword(int id, string currentPassword, string newPassword)
        {
            try
            {
                return Ok(_clientService.EditPassword(id, currentPassword, newPassword));
            }
            catch (Exception e)
            {                
                return StatusCode(500, new Resposta(500, e.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                return Ok(_clientService.DeleteClient(id));
            }
            catch (Exception e)
            {                
                return StatusCode(500, new Resposta(500, e.Message));
            }
        }

        [HttpPut]
        public IActionResult UpdadteDiceClient(Client updateDiceClient)
        {
            try
            {
                return Ok(_clientService.UpdateDiceClient(updateDiceClient));
            }
            catch (Exception e)
            {                
                return StatusCode(500, new Resposta(500, e.Message));
            }
        }

        public class Resposta
        {
            public Resposta(int status, string mensagem)
            {
                this.Status = status;
                this.Mensagem = mensagem;

            }
          
            public int Status { get; set; }
            public string Mensagem { get; set; }

        }
    }
}
