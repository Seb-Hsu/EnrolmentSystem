using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnrolmentSystem.Service;
using EnrolmentSystem.Model;

namespace EnrolmentSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnrolmentController : ControllerBase
    {
        //GET: /Student
        [HttpGet("Student")]
        public ActionResult<List<Student>> GetAllStudents()=> EnrolmentService.GetAllStudents();

        //GET: /Course
        [HttpGet("Course")]
        public ActionResult<List<Course>> GetAllCourses()=>EnrolmentService.GetAllCourses();

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
    }
}
