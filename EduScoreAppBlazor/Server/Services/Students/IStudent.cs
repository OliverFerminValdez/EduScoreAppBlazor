using EduScoreAppBlazor.Shared.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EduScoreAppBlazor.Server.Services.Students
{
    public interface IStudent
    {
        public Task<List<Student>> GetStudents(); 
        public Task<Student> GetStudent(int id);
        public Task<Student> AddStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudent(int id);
    }
}
