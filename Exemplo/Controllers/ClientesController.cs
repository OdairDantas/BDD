using Exemplo.WebApp.Models;
using Exemplo.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ClientesController: ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            var response = _clienteService.Adicionar(cliente);
            return Ok(new { id = response });
        }

    }
}
