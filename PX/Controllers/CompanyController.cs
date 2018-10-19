using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PX.API.IServices;
using PX.API.Models;

namespace PX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchModel searchModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _companyService.SearchAsync<CompanyModel>(searchModel);
            return Ok(new {Results = result});
        }

        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CompanyModel companyModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _companyService.CreateAsync(companyModel);
            return Created("", new {Id = id});
        }
        
        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}