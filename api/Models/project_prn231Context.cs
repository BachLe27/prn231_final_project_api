using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class project_prn231Context : DbContext
    {
        public project_prn231Context()
        {
        }

        public project_prn231Context(DbContextOptions<project_prn231Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Contest> Contests { get; set; } = null!;
        public virtual DbSet<StudentsClass> StudentsClasses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Submission> Submissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=localhost;database=project_prn231;user=g3;password=123456;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__Classes__teacher__3A81B327");
            });

            modelBuilder.Entity<Contest>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Question)
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Contests)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Contests__class___403A8C7D");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Contests)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__Contests__subjec__3F466844");
            });

            modelBuilder.Entity<StudentsClass>(entity =>
            {
                entity.ToTable("Students_Classes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.StudentsClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students___class__440B1D61");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsClasses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Students___stude__4316F928");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsUnicode(false)
                    .HasColumnName("content");

                entity.Property(e => e.ContestId).HasColumnName("contest_id");

                entity.Property(e => e.Grade).HasColumnName("grade");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubmissionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("submission_time");

                entity.Property(e => e.TeacherFeedback)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("teacher_feedback");

                entity.HasOne(d => d.Contest)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.ContestId)
                    .HasConstraintName("FK__Submissio__conte__47DBAE45");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Submissio__stude__46E78A0C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5723E6A3B24")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
