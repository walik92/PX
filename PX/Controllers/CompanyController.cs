using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PX.API.Models;
using PX.DAL.DTO;
using PX.DAL.IRepository;

namespace PX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        // GET api/company/search
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            var companies = await _companyRepository.GetAllAsync();
            return Ok(companies);
        }

        // POST api/company/create
        [HttpPost("create")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CompanyModel companyModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var company = _mapper.Map<Company>(companyModel);
            var id = await _companyRepository.AddAsync(company);
            return Created("", new { Id = id });
        }

        // PUT api/values/5
        [HttpPut("update/{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}