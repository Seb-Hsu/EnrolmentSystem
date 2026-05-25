using EnrolmentSystem.Model;
using EnrolmentSystem.Service;
using Microsoft.AspNetCore.Mvc;

namespace EnrolmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnrolmentController : ControllerBase
    {
        //GET: /Student
        [HttpGet("Student")]
        public ActionResult<List<Student>> GetAllStudents() => EnrolmentService.GetAllStudents();

        //GET: /Course
        [HttpGet("Course")]
        public ActionResult<List<Course>> GetAllCourses() => EnrolmentService.GetAllCourses();

        //Get: /Enrolment
        [HttpGet("Enrolment")]
        public ActionResult<List<Enrolment>> GetAllEnrolments() => EnrolmentService.GetAllEnrolments();

        //POST: /Student
        [HttpPost("Student")]
        public IActionResult Create(Student s)
        {
            EnrolmentService.AddStudent(s);
            return CreatedAtAction(nameof(GetAllStudents), s);
        }

        //POST: /Course
        [HttpPost("Course")]
        public IActionResult Create(Course c)
        {
            EnrolmentService.AddCourse(c);
            return CreatedAtAction(nameof(GetAllCourses), c);
        }

        //POST: /Enrolment
        [HttpPost("Enrolment")]
        public IActionResult Create(Enrolment e)
        {
            EnrolmentService.AddEnrolment(e);
            return CreatedAtAction(nameof(GetAllEnrolments), e);
        }
    }
}
