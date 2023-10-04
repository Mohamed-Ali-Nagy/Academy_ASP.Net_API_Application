using Academy.DTO;
using Academy.Models;
using Academy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository courseRepo;
        public CourseController(ICourseRepository _courseRepo)
        {
            courseRepo = _courseRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses=courseRepo.GetAll();
            if (courses == null) return NotFound();

            var coursesDTO = courses.Select(c => new CourseDTO
            {
                Id = c.Id,
                Cost = c.Cost,
                NoOfHours = c.NoOfHours,
                CourseName = c.CourseName,
                CourseDescription = c.CourseDescription,
            });
            return Ok(coursesDTO);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            Course course = courseRepo.GetById(id);
            if (course == null) return NotFound();

            CourseDTO courseDTO=new CourseDTO()
            {
                Id=course.Id,
                CourseDescription=course.CourseDescription,
                CourseName=course.CourseName,
                Cost=course.Cost,
                NoOfHours=course.NoOfHours,
            };

            return Ok(courseDTO);
        }
        [HttpPost]
        public IActionResult Add(CourseDTO courseDTO)
        {
            if (courseDTO == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            Course course = new Course()
            {
                Id = courseDTO.Id,
                Cost = courseDTO.Cost,
                NoOfHours= courseDTO.NoOfHours,
                CourseName = courseDTO.CourseName,
                CourseDescription= courseDTO.CourseDescription,
            };
            courseRepo.Add(course);
            courseRepo.Save();
            return CreatedAtAction(nameof(GetById), new {id=course.Id},courseDTO);
        }

        [HttpPut]
        public IActionResult Update(CourseDTO courseDTO,int id)
        {
            if(courseDTO == null) return BadRequest("The course can not be null");
            if (id != courseDTO.Id) return BadRequest("Thd id dose not equal cours id ");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            Course course = courseRepo.GetById(id);
            if (course == null) return NotFound();
            course.Id = courseDTO.Id;
            course.Cost = courseDTO.Cost;
            course.NoOfHours = courseDTO.NoOfHours;
            course.CourseName = courseDTO.CourseName;
            course.CourseDescription = courseDTO.CourseDescription;
            courseRepo.Update(course);
            courseRepo.Save();
            return Ok();
        }

        [HttpDelete] public IActionResult Delete(int id)
        {
            Course course=courseRepo.GetById(id);   
            if (course == null) return NotFound();
            courseRepo.Delete(course);
            courseRepo.Save();
            return Ok();
        }
    }
}
