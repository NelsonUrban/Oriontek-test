using CustomerApi.BusinessLogic.Dtos;
using CustomerApi.BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var clients = clientService.GetAll();
            return Ok(clients);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var clients = clientService.GetClientById(id);
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult Post([FromBody] ClientDto clientDto)
        {
            clientService.Create(clientDto);
            return Created("", clientDto);
        }
        [HttpPut]
        public IActionResult Put([FromBody] ClientDto clientDto)
        {
            clientService.Update(clientDto);
            return Ok();
        }
    }
}
