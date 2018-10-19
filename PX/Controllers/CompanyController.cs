using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PX.API.IServices;
using PX.API.Models;

namespace PX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyService companyService, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchModel searchModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _companyService.SearchAsync<CompanyModel>(searchModel);
            return Ok(new {Results = result});
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CompanyModel companyModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _companyService.CreateAsync(companyModel);
            return Created("", new {Id = id});
        }

        [HttpPut("update/{companyId}")]
        public async Task<IActionResult> Put(int companyId, [FromBody] CompanyModel companyModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _companyService.UpdateAsync(companyId, companyModel);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound($"Not found company by Id {companyId}");
            }
        }

        [HttpDelete("delete/{companyId}")]
        public async Task<IActionResult> Delete(int companyId)
        {
            try
            {
                await _companyService.DeleteAsync(companyId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound($"Not found company by Id {companyId}");
            }
        }
    }
}