using System;
using System.Collections.Generic;
using ElearningDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ElearningDB.Data;

public partial class ElearningDbContext : DbContext
{
    public ElearningDbContext()
    {
    }

    public ElearningDbContext(DbContextOptions<ElearningDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<SubCourse> SubCourses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ElearningDB;Integrated Security=True;Encrypt=True");

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Video>()
    //        .HasOne(v => v.Course)
    //        .WithMany(c => c.Videos)
    //        .HasForeignKey(v => v.CourseId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<Video>()
    //        .HasOne(v => v.SubCourse)
    //        .WithMany(sc => sc.Videos)
    //        .HasForeignKey(v => v.SubCourseId)
    //        .OnDelete(DeleteBehavior.Restrict);

    //    modelBuilder.Entity<SubCourse>()
    //        .HasOne(sc => sc.Course)
    //        .WithMany(c => c.SubCourses)
    //        .HasForeignKey(sc => sc.CourseId)
    //        .OnDelete(DeleteBehavior.Cascade);
    //}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");
        });

        modelBuilder.Entity<SubCourse>(entity =>
        {
            entity.ToTable("SubCourse");

            entity.HasIndex(e => e.CourseId, "IX_SubCourse_CourseId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Course).WithMany(p => p.SubCourses).HasForeignKey(d => d.CourseId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.ToTable("Video");

            entity.HasIndex(e => e.CourseId, "IX_Video_CourseId");

            entity.HasIndex(e => e.SubCourseId, "IX_Video_SubCourseId");

            entity.HasOne(d => d.Course).WithMany(p => p.Videos)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SubCourse).WithMany(p => p.Videos)
                .HasForeignKey(d => d.SubCourseId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });




        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
