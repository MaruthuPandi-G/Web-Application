using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Online_Course.Models.Blog;
using Online_Course.Models.Register;

namespace Online_Course.Models
{
    public partial class CourseDbContext : DbContext
    {
        public CourseDbContext()
        {
        }

        public CourseDbContext(DbContextOptions<CourseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseDetail> CourseDetails { get; set; } = null!;
        public virtual DbSet<FeedbackDetail> FeedbackDetails { get; set; } = null!;
        public virtual DbSet<SubscriberDetail> SubscriberDetails { get; set; } = null!;
        public virtual DbSet<RegisterModel> UserRegisterDetails { get; set; } = null!;
        public virtual DbSet<BlogDetail> BlogDetails { get; set; } = null!;
        public virtual DbSet<UserCoursesDetails> UserCourses { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CourseDb;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDetail>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__CourseDe__C92D71A75C3BBB09");

                entity.HasIndex(e => e.CourseName, "UQ__CourseDe__9526E2779F7A78D5")
                    .IsUnique();

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CourseImage)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CourseName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeedbackDetail>(entity =>
            {
                entity.HasKey(e => e.FeedbackId)
                    .HasName("PK__Feedback__6A4BEDD636A5017B");

                entity.HasIndex(e => e.Email, "UQ__Feedback__A9D10534873DD8B3")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeedbackMessage)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubscriberDetail>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Subscrib__A9D1053420542776")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegisterModel>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C71C1C820");

                entity.ToTable("UserDetail");

                entity.HasIndex(e => e.Password, "UQ__UserDeta__87909B15385C557C")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__UserDeta__A9D10534E389CF96")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BlogDetail>(entity =>
            {
                entity.HasKey(e => e.BlogId)
                    .HasName("PK__BlogDeta__54379E30F02D7260");
            });

            modelBuilder.Entity<UserCoursesDetails>(entity =>
            {
                entity.HasKey(e => e.SNo)
                    .HasName("PK__UserCour__A3DD670AB6AA9CAD");

                entity.Property(e => e.SNo).HasColumnName("S_No");
            });

            OnModelCreatingPartial(modelBuilder);           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
