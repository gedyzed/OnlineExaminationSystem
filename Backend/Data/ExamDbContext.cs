using Microsoft.EntityFrameworkCore;
using Backend.Data.Models;
namespace Backend.Data;

public class ExamDbContext : DbContext
{
    public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students{ get; set; }
    public DbSet<Teacher> Teachers{ get; set; }
    public DbSet<Admin> Admins{ get; set; }
    public DbSet<Exam> Exams{ get; set; }
    public DbSet<Question> Questions{ get; set; }
    public DbSet<User> Users{ get; set; }
    public DbSet<Report> Reports{ get; set; }
    public DbSet<Schedule> Schedules{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<Student>()
        .HasKey(s => s.StudentId);

    modelBuilder.Entity<Admin>()
        .HasKey(a => a.AdminId);

    modelBuilder.Entity<Teacher>()
        .HasKey(t => t.TeacherId);
    
    modelBuilder.Entity<User>()
        .HasKey(u => u.UserID);

    modelBuilder.Entity<Report>()
        .HasKey(r => new { r.StudentId, r.ExamId });

    modelBuilder.Entity<Question>()
        .HasKey(q => new { q.QuestionId, q.ExamId });

    modelBuilder.Entity<Schedule>()
        .HasKey(s => new { s.AdminId, s.ExamId }); 

    modelBuilder.Entity<Exam>()
        .HasKey(e => e.ExamID);

    // Relationships and Foreign Keys
    modelBuilder.Entity<User>()
        .HasOne(u => u.Student)
        .WithOne(s => s.User)
        .HasForeignKey<Student>(s => s.UserID);

    modelBuilder.Entity<User>()
        .HasOne(u => u.Admin)
        .WithOne(a => a.User)
        .HasForeignKey<Admin>(a => a.UserID);

    modelBuilder.Entity<User>()
        .HasOne(u => u.Teacher)
        .WithOne(t => t.User)
        .HasForeignKey<Teacher>(t => t.UserID);

    modelBuilder.Entity<Student>()
        .HasMany(s => s.Reports)
        .WithOne(r => r.Student)
        .HasForeignKey(r => r.StudentId);

    modelBuilder.Entity<Admin>() 
        .HasMany(a => a.Schedules)
        .WithOne(s => s.Admin)
        .HasForeignKey(s => s.AdminId); 

    modelBuilder.Entity<Exam>()
        .HasMany(e => e.Reports)
        .WithOne(r => r.Exam)
        .HasForeignKey(r => r.ExamId); 
/*
    modelBuilder.Entity<Choice>()
        .HasOne(c => c.Question)
        .WithMany(q => q.Choices)
        .HasForeignKey(c => new{ c.QuestionId, c.ExamId})
        .OnDelete(DeleteBehavior.NoAction);
*/

    modelBuilder.Entity<Exam>()
        .HasMany(e => e.Questions)
        .WithOne(q => q.Exam)
        .HasForeignKey(q => q.ExamId);
/*
    modelBuilder.Entity<Exam>()
        .HasMany(e => e.Choices)
        .WithOne(c => c.Exam)
        .HasForeignKey(c => c.ExamId); 
        */
}


}