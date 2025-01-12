using System;
using System.Collections.Generic;
using K01Y25_Nhom4_BT02.DB.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace K01Y25_Nhom4_BT02.DB
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.Property(e => e.Courseid)
                    .HasColumnName("courseid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Credits).HasColumnName("credits");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("enrollment");

                entity.Property(e => e.Enrollmentid)
                    .HasColumnName("enrollmentid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Courseid).HasColumnName("courseid");

                entity.Property(e => e.Grade)
                    .HasPrecision(4, 2)
                    .HasColumnName("grade");

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.Courseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Enrollmentdate).HasColumnName("enrollmentdate");

                entity.Property(e => e.Firstmidname)
                    .HasMaxLength(50)
                    .HasColumnName("firstmidname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .HasColumnName("lastname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
