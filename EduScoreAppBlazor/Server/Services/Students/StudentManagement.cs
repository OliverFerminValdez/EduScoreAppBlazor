using EduScoreAppBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EduScoreAppBlazor.Server.Services.Students
{
    public class StudentManagement : IStudent
    {
        readonly AppDbContext dbContext = new AppDbContext();
        public StudentManagement(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Student> AddStudent(Student student)
        {
            try
            {
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
                return student;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                Student? student = await dbContext.Students.FindAsync(id);

                if (student != null)
                {
                    dbContext.Students.Remove(student);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            try
            {
                Student? student = await dbContext.Students
                        .Where(s => s.Id_Student == id)
                        .Include(s => s.ScoreDetail)
                        .FirstOrDefaultAsync();

                if (student == null)
                    throw new ArgumentNullException();

                return student;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await dbContext.Students.ToListAsync();
            }
            catch (Exception) 
            { 
                throw; 
            }
        }

        public async Task UpdateStudent(Student student)
        {
            try
            {
                dbContext.Database.ExecuteSqlRaw($"Delete FROM ScoreDetail Where Id_Student={student.Id_Student}");

                foreach (var item in student.ScoreDetail)
                {
                    dbContext.Database.ExecuteSqlRaw($"Insert into ScoreDetail (Id_Student, Id_Subject, Score) values ({item.Id_Student},{item.Id_Subject},{item.Score})");
                }

                dbContext.Students.Update(student);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
