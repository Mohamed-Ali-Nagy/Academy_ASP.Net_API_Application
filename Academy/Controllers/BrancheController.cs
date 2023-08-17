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
            var courses=brancheRepo.GetAll();
            if(courses==null) 
            {
                return NotFound();
            }
            return Ok(courses);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Branche branche=brancheRepo.GetById(id);
            if(branche==null) return NotFound();
            return Ok(branche);
        }

        //[HttpPost]
        //public IActionResult Add(BrancheDTO brancheDTO)
        //{
        //    if(brancheDTO==null) return BadRequest();  
        //    if(!ModelState.IsValid) return BadRequest();

        //    brancheService.Add(branche);
        //    brancheService.Save();
        //    return CreatedAtAction(nameof(GetById), new { id = branche.Id }, branche);
        //}




    }
}
