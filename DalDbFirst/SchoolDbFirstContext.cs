using System;
using System.Collections.Generic;
using DalDbFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DalDbFirst
{
    public partial class SchoolDbFirstContext : DbContext
    {
        public SchoolDbFirstContext()
        {
        }

        public SchoolDbFirstContext(DbContextOptions<SchoolDbFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrative> Administratives { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=MySchoolDatabase;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("Classroom");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.Property(e => e.Classname)
                    .HasMaxLength(30)
                    .HasColumnName("classname");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(70);
            });

            modelBuilder.Entity<Administrative>(entity =>
            {
                entity.ToTable("Administrative");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.HasIndex(e => e.ClassroomId, "IX_Student_ClassroomID");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.HasOne(d => d.Classroom)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassroomId);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {

                entity.ToTable("Teacher");

                entity.HasIndex(e => e.ClassroomId, "IX_Teacher_ClassroomID")
                    .IsUnique()
                    .HasFilter("([ClassroomID] IS NOT NULL)");

                entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");

                entity.Property(e => e.Discipline).HasMaxLength(30);

                entity.HasOne(d => d.Classroom)
                    .WithOne(p => p.Teacher)
                    .HasForeignKey<Teacher>(d => d.ClassroomId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
