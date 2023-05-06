
using EduScoreAppBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EduScoreAppBlazor.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("defaultConnection"));

            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Subject>().HasData(new Subject
            {
                Id_Subject = 1,
                Name = "Maths"
            });

            model.Entity<Subject>().HasData(new Subject
            {
                Id_Subject = 2,
                Name = "English"
            });

        }

    }
}
    