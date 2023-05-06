using EduScoreAppBlazor.Server.Services.Students;
using EduScoreAppBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EduScoreAppBlazor.Server.Services.Subjects
{
    public class SubjectManagment :  ISubject
    {
        readonly AppDbContext dbContext = new AppDbContext();

        public SubjectManagment(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            try
            {
                await dbContext.Subjects.AddAsync(subject);
                await dbContext.SaveChangesAsync();
                return subject;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteSubject(int id)
        {
            try
            {
                Subject? subject = await dbContext.Subjects.FindAsync(id);
                if (subject != null)
                {
                    dbContext.Subjects.Remove(subject);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task<Subject> GetSubject(int id)
        {
            try
            {
                Subject? subject = await dbContext.Subjects.FindAsync(id);
                if (subject == null)
                    throw new ArgumentNullException();

                return subject;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Subject>> GetSubjects()
        {
            try
            {
                return await dbContext.Subjects.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateSubject(Subject subject)
        {
            try
            {
                if (dbContext.Subjects.Any(s => s.Id_Subject == subject.Id_Subject))
                {
                    dbContext.Subjects.Update(subject);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
