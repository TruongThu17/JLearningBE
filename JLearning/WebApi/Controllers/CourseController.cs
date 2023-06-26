using AutoMapper;
using BusinessObjects.DTO;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Reporitories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // Repository
        private ICourseRepository repository = new CourseRepository();

        // Mapper
        private readonly IMapper _mapper;

        // Get mapper singleton
        public CourseController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET: api/<CourseController>
        [HttpGet("get")]
        public ActionResult<IEnumerable<CourseDTO>> Get()
        {
            IEnumerable<Course> courses = repository.GetCourses();
            IEnumerable<CourseDTO> courseDTOs = _mapper.Map<IEnumerable<CourseDTO>>(courses);
            return Ok(courseDTOs);
        }

        // GET api/<BlogController>/5
        [HttpPost("get/by-id")]
        public ActionResult Get(int course_id)
        {
            var course = repository.FindCourseById(course_id);
            if (course == null) return NotFound();
            CourseDTO courseDTO = _mapper.Map<CourseDTO>(course);
            return Ok(courseDTO);
        }

        // POST api/<CourseController>
        [HttpPost("insert")]
        public ActionResult Post([FromBody][Bind("course_avatar_url,course_name,created_at," +
            "description,duration,price,status")] CourseDTO courseDTO)
        {
                Course course = _mapper.Map<Course>(courseDTO);
                repository.CreateCourse(course);
                return Ok();
        }

        // PUT api/<CourseController>/5
        [HttpPost("update")]
        public ActionResult Put([FromBody][Bind("course_id,course_avatar_url,course_name,created_at," +
            "description,duration,price,status")] CourseDTO courseDTO)
        {
            var course = repository.FindCourseById((int)courseDTO.CourseId);
            if (course == null) return NotFound();
            Course cours = _mapper.Map<Course>(courseDTO);
            repository.UpdateCourse(cours);
            return Ok();
        }

        [HttpPost("get/user-courses")]
        public ActionResult<IEnumerable<CourseDTO>> GetCourse(string email)
        {
            IEnumerable<Course> courses = repository.FindCoursesByEmail(email);
            IEnumerable<CourseDTO> courseDTOs = _mapper.Map<IEnumerable<CourseDTO>>(courses);
            return Ok(courseDTOs);
        }

        [HttpPost("insert/user-course")]
        public ActionResult PostUserCourse([FromBody][Bind("course_id,email,enrolled_date")] UserCourseDTO userCourseDTO)
        {
            UserCourse userCourse = _mapper.Map<UserCourse>(userCourseDTO);
            repository.CreateUserCourse(userCourse);
            return Ok();
        }
    }
}
