using Microsoft.EntityFrameworkCore;

namespace Udemy.Cqrs.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student { Id = 1, Name="Emre", Surname="Coru", Age=22},
                new Student { Id = 2, Name="Ahmet", Surname="Soyisim", Age=23}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
