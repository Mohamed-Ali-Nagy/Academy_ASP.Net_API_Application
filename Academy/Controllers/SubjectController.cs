using Academy.DTO;
using Academy.Models;
using Academy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRepository subjectRepo;
        public SubjectController(ISubjectRepository _subjectRepo)
        {
            subjectRepo = _subjectRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var subjects = subjectRepo.GetAll();
            if (subjects == null) return NotFound();

            var subjectsDTO = subjects.Select(s => new SubjectDTO
            {
                SubjectID = s.Id,
                SubjectName = s.SubjectName,
                CourseName = s.Course.CourseName,
                CourseID=s.CourseId,
            }).ToList().OrderBy(c=>c.CourseName);

            return Ok(subjectsDTO);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var subject = subjectRepo.GetById(id);
            if (subject == null) return NotFound();
            SubjectDTO subjectDTO=new SubjectDTO 
            {
                SubjectID = subject.Id,
                SubjectName = subject.SubjectName,
                CourseName = subject.Course.CourseName,
                CourseID=subject.CourseId,
                
            };
            return Ok(subjectDTO);
        }

        [HttpPost]
        public IActionResult Add(SubjectDTO subjectDTO)
        {
            if (subjectDTO == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
           
            Subject newSubject= new Subject()
            {
                SubjectName = subjectDTO.SubjectName,
                CourseId=subjectDTO.CourseID,     
            };
            subjectRepo.Add(newSubject);
            subjectRepo.Save();
            return CreatedAtAction(nameof(GetById), new { id = newSubject.Id }, subjectDTO);
        }

        [HttpPut]
        public IActionResult Update(SubjectDTO subjectDTO,int id)
        {
            if(subjectDTO==null||subjectDTO.SubjectID!=id||!ModelState.IsValid) return BadRequest();

            Subject subject= subjectRepo.GetById(id);
            if (subject == null) return NotFound();
            subject.SubjectName = subjectDTO.SubjectName;
            subject.Id = id;
            subject.CourseId = subjectDTO.CourseID;
            
            subjectRepo.Update(subject);
            subjectRepo.Save();
            return Ok(subject);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var subject= subjectRepo.GetById(id);
            if (subject == null) return NotFound();

            subjectRepo.Delete(subject);
            subjectRepo.Save();
            return Ok();
        }




    }
}
