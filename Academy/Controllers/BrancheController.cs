using Academy.Data.DTO;
using Academy.Data.Repository;
using Academy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrancheController : ControllerBase
    {
        private readonly IBrancheRepository brancheRepo;
        public BrancheController(IBrancheRepository _brancheRepo)
        {
            brancheRepo = _brancheRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            List<Branche> branches = brancheRepo.GetAll();
            if (branches == null)
            {
                return NotFound();
            }
            List<BrancheDTO> brancheDTOs = branches.Select(b => new BrancheDTO
            {
                BrancheId = b.Id,
                BrancheName = b.Name,
                BranchePhoneNumber = b.PhoneNumber,
                BrancheSupervisorName = b.SupervisorName
            }).ToList();
            return Ok(brancheDTOs);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Branche branche = brancheRepo.GetById(id);
            if (branche == null) return NotFound();
            BrancheDTO brancheDTO = new BrancheDTO()
            {
                BrancheId = branche.Id,
                BrancheSupervisorName = branche.SupervisorName,
                BranchePhoneNumber = branche.PhoneNumber,
                BrancheName = branche.Name,

            };
            return Ok(brancheDTO);
        }

        [HttpPost]
        public IActionResult Add(BrancheDTO brancheDTO)
        {
            if (brancheDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            Branche branche = new Branche()
            {
                Name = brancheDTO.BrancheName,
                SupervisorName = brancheDTO.BrancheSupervisorName,
                PhoneNumber = brancheDTO.BranchePhoneNumber,
            };
            brancheRepo.Add(branche);
            brancheRepo.Save();
            return CreatedAtAction(nameof(GetById), new { id = branche.Id }, brancheDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Update(BrancheDTO brancheDTO,int id)
        {
            if(brancheDTO==null) return BadRequest();
            if(id!=brancheDTO.BrancheId) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();

            Branche branche=brancheRepo.GetById(id);
            branche.Id= id;
            branche.Name= brancheDTO.BrancheName;
            branche.PhoneNumber= brancheDTO.BranchePhoneNumber;
            branche.SupervisorName = brancheDTO.BrancheSupervisorName;

            brancheRepo.Update(branche);
            brancheRepo.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var branche = brancheRepo.GetById(id);
           if ( branche==null) return NotFound();

           brancheRepo.Delete(branche);
           brancheRepo.Save();
           return Ok();

        }
    }
}
