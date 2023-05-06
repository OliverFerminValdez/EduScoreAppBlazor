using EduScoreAppBlazor.Shared.Models;

namespace EduScoreAppBlazor.Server.Services.Subjects
{
    public interface ISubject
    {
        public Task<List<Subject>> GetSubjects();
        public Task<Subject> GetSubject(int id);
        public Task<Subject> AddSubject(Subject subject);
        public Task UpdateSubject(Subject subject);
        public Task DeleteSubject(int id);
    }
}
