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
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;


        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
         
        }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var courses= await _courseRepository.GetCourses();
            return Ok(courses);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }

    }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var course= await _courseRepository.GetCourse(Id);
                return Ok(course);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCourseDTO courseDto)
        {
            try
            {
                Course newCourse = new Course()
                {
                    Name = courseDto.Name,
                   
                };

                var course = await _courseRepository.Save(newCourse );

                return Ok(course);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

            
