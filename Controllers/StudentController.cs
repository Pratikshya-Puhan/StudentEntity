using StudentEntity.Model;
using StudentEntity.Repository;
using StudentEntity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace StudentEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IFileUploadService _uploadService;


        public StudentController(IStudentRepository studentRepository, IFileUploadService uploadService)
        {
            _studentRepository = studentRepository;
            _uploadService = uploadService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var students = await _studentRepository.GetStudents();
                return Ok(students);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpGet]

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var student = await _studentRepository.GetStudents(Id);
                return Ok(student);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Add([FromForm] CreateStudentDTO studentDto)
        {
            try
            {
                Student newStudent = new Student()
                {

                    Name = studentDto.Name,
                    Gender = studentDto.Gender,
                    City = studentDto.City,
                    CourseId = studentDto.CourseId,
                    PictureURL = ""

                };

                if (studentDto.File != null)
                {
                    newStudent.PictureURL = await _uploadService.SingleUpload(studentDto.File, Request);
                }

                var student = await _studentRepository.Save(newStudent);

                return Ok(student);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

   

            

    

