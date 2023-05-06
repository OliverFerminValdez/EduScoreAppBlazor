using EduScoreAppBlazor.Server.Services.Subjects;
using EduScoreAppBlazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace EduScoreAppBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject iSubject;
        public SubjectController(ISubject iSubject)
        {
            this.iSubject = iSubject;
        }
        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetSubjects()
        {
            List<Subject> subjects = await iSubject.GetSubjects();
            if (subjects.Count <= 0)
                return NoContent();

            return Ok(subjects);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            Subject subject = await iSubject.GetSubject(id);
            if (subject != null)
                return Ok(subject);

            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
            await iSubject.AddSubject(subject);
            return CreatedAtAction(nameof(GetSubject), new { id = subject.Id_Subject }, subject);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Subject>> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id_Subject)
            {
                return BadRequest();
            }
            await iSubject.UpdateSubject(subject);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subject>> DeleteSubject(int id)
        {
            Subject subject = await iSubject.GetSubject(id);
            if (subject == null)
                return NotFound();

            await iSubject.DeleteSubject(id);
            return Ok(subject);
        }
    }
}
