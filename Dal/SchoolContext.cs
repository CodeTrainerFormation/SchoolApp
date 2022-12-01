using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MySchoolDatabase;Integrated Security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Classroom>().ToTable("Classrooms");
        //    modelBuilder.Entity<Person>().ToTable("People");
        //    modelBuilder.Entity<Student>().ToTable("Students");
        //    modelBuilder.Entity<Teacher>().ToTable("Teachers");

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}