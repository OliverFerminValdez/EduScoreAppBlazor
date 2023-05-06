using EduScoreAppBlazor.Server.Services.Students;
using EduScoreAppBlazor.Server.Services.Subjects;
using EduScoreAppBlazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduScoreAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent iStudent;

        public StudentController(IStudent iStudent)
        {
            this.iStudent = iStudent;
        }
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetStudents()
        {
            List<Student> student = await iStudent.GetStudents();
            if (student.Count <= 0)
                return NoContent();

            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            Student student = await iStudent.GetStudent(id);
            if (student != null)
                return Ok(student);

            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            await iStudent.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id_Student }, student);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> PutSubject(int id, Student student)
        {
            if (id != student.Id_Student)
            {
                return BadRequest();
            }
            await iStudent.UpdateStudent(student);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteStudent(int id)
        {
            Student student = await iStudent.GetStudent(id);
            if (student == null)
                return NotFound();

            await iStudent.DeleteStudent(id);
            return Ok(student);
        }
    }
}
