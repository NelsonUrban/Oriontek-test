using CustomerApi.BusinessLogic.Dtos;
using CustomerApi.BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var companies = companyService.GetAll();
            return Ok(companies);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var clients = companyService.GetCompanyById(id);
            return Ok(clients);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CompanyDto  companyDto)
        {
            companyService.Create(companyDto);
            return Created("", companyDto);
        }
        [HttpPut]
        public IActionResult Put([FromBody] CompanyDto companyDto)
        {
            companyService.Update(companyDto);
            return Ok();
        }
    }
}
