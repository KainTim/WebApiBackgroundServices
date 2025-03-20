using Microsoft.EntityFrameworkCore;

namespace WebApiBackgroundServicesDbLib;

public class ApiContext : DbContext
{
    public DbSet<Clazz> Clazzes { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine("OnConfiguring");
        if (optionsBuilder.IsConfigured) return;
        Console.WriteLine("Using Sqlite");
        optionsBuilder.UseSqlite("data source=/home/tikaiz/Databases/ApiBackgroundServices.db");
    }
}