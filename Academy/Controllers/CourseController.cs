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
        
    }
}
