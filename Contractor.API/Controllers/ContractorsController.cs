using Contractor.API.Dtos;
using Contractor.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Contractor.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContractorsController : ControllerBase
    {
        private readonly IContractorRepository _contractorRepository;

        public ContractorsController(IContractorRepository contractorRepository)
        {
            _contractorRepository = contractorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Contractor>>> GetAll()
        {
            var contractors = await _contractorRepository.GetAllAsync();

            return Ok(contractors);
        }

        [HttpGet("{contractorId}")]
        public async Task<ActionResult<ContractorDto>> GetContractor(Guid contractorId)
        {
            var contractor = await _contractorRepository.GetAsync(contractorId);

            if (contractor == null)
            {
                return NotFound();
            }

            return Ok(contractor);
        }
        [HttpPost]
        public async Task<ActionResult<ContractorDto>> CreateContractor([FromBody] ContractorDto contractorDto)
{
    // Perform any necessary validation on the contractorDto object

    if (!ModelState.IsValid)
    {
        // If the contractorDto object fails validation, return a BadRequest response
        return BadRequest(ModelState);
    }

    var contractor = new Entities.Contractor
    {
        Id = Guid.NewGuid(),
        Name = contractorDto.Name,
        Nip = contractorDto.Nip,
        PhoneNo = contractorDto.PhoneNo,
        Email = contractorDto.Email
    };

    await _contractorRepository.AddAsync(contractor);

    var createdContractorDto = new ContractorDto
    {
        Id = contractor.Id,
        Name = contractor.Name,
        Nip = contractor.Nip,
        PhoneNo = contractor.PhoneNo,
        Email = contractor.Email
    };

    // Return a CreatedAtAction response with the created contractor DTO
    return CreatedAtAction(nameof(GetContractor), new { contractorId = contractor.Id }, createdContractorDto);
}

    }
}
