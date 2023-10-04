using Academy.DTO;
using Academy.Models;
using Academy.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepo;
        public StudentController(IStudentRepository _studentRepo)
        {
           studentRepo = _studentRepo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students = studentRepo.GetAll();
            if (students == null) return NotFound();

            var studentsDTO = students.Select(s => new StudentDTO
            {
                Id = s.Id,
                NationalID = s.NationalID,
                BirthDate = s.BirthDate,
                Address = s.Address,
                SubmissionDate = s.SubmissionDate,
                Gender = s.Gender,
                LandlinePhone = s.LandlinePhone,
                PhoneNumber = s.PhoneNumber,
                MilitaryStatus = s.MilitaryStatus,
                Qualification= s.Qualification, 
                Religion= s.Religion,
                StudentName = s.StudentName,
                QualificationObtainingYear = s.QualificationObtainingYear,
                BrancheId = s.BrancheId,    
                BrancheName=s.Branche.Name,
            }).ToList();

            return Ok(studentsDTO);

        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var student=studentRepo.GetById(id);
            if (student == null) return NotFound();

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                NationalID = student.NationalID,
                BirthDate = student.BirthDate,
                Address = student.Address,
                SubmissionDate = student.SubmissionDate,
                Gender = student.Gender,
                LandlinePhone = student.LandlinePhone,
                PhoneNumber = student.PhoneNumber,
                MilitaryStatus = student.MilitaryStatus,
                Qualification = student.Qualification,
                Religion = student.Religion,
                StudentName = student.StudentName,
                QualificationObtainingYear = student.QualificationObtainingYear,
                BrancheId = student.BrancheId,
                BrancheName = student.Branche.Name,
            };

            return Ok(studentDTO);  
        }

        [HttpPost]
        public IActionResult Add(StudentDTO studentDTO) 
        {
            if (studentDTO == null) return BadRequest("Student can not be null");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            Student student = new Student()
            {
                Id = studentDTO.Id,
                NationalID = studentDTO.NationalID,
                BirthDate = studentDTO.BirthDate,
                Address = studentDTO.Address,
                SubmissionDate = studentDTO.SubmissionDate,
                Gender = studentDTO.Gender,
                LandlinePhone = studentDTO.LandlinePhone,
                PhoneNumber = studentDTO.PhoneNumber,
                MilitaryStatus = studentDTO.MilitaryStatus,
                Qualification = studentDTO.Qualification,
                Religion = studentDTO.Religion,
                StudentName = studentDTO.StudentName,
                QualificationObtainingYear = studentDTO.QualificationObtainingYear,
                BrancheId = studentDTO.BrancheId,

            };
            studentRepo.Add(student);
            studentRepo.Save();
            return CreatedAtAction(nameof(Get), new {Id=studentDTO.Id}, studentDTO);
        }

        [HttpPut]
        public IActionResult Update(StudentDTO studentDTO ,int id)
        {
            if(studentDTO==null) return BadRequest("student can not be null");
            if (studentDTO.Id != id) return BadRequest("The ID dose not equale student ID");
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var student = studentRepo.GetById(studentDTO.Id);
            if (student==null) return NotFound();

            student.SubmissionDate = studentDTO.SubmissionDate;
            student.PhoneNumber = studentDTO.PhoneNumber;
            student.LandlinePhone = studentDTO.LandlinePhone;   
            student.BirthDate = studentDTO.BirthDate;
            student.Gender = studentDTO.Gender;
            student.Address = studentDTO.Address;
            student.BrancheId = studentDTO.BrancheId;
            student.StudentName = studentDTO.StudentName;
            student.Id= studentDTO.Id;

            studentRepo.Update(student);
            studentRepo.Save();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
           var student= studentRepo.GetById(id);
           if (student==null) return NotFound();
            studentRepo.Delete(student);
            studentRepo.Save();
            return Ok();
        }

    }
}
