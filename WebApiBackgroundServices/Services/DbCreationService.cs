using WebApiBackgroundServicesDbLib;

namespace WebApiBackgroundServices.Services;

public class DbCreationService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApiContext>();
        Console.WriteLine("EnsureDeleted");
        db.Database.EnsureDeleted();
        Console.WriteLine("EnsureCreated");
        db.Database.EnsureCreated();
        AssertDbSeeded(db);
        return Task.CompletedTask;
    }

    private static void AssertDbSeeded(ApiContext db)
    {
        Console.WriteLine("AssertDbSeeded");
        if (db.Courses.Any()) return;
        Console.WriteLine("Seeding");
        var section = new Section();
        db.Sections.Add(section);
        var instructor = new Instructor()
        {
            InstructorFaculty = "Math",
            InstructorName = "Jane Doe",
        };
        db.Instructors.Add(instructor);
        var student = new Student()
        {
            StudentAddress = "1234 Main St",
            StudentName = "John Doe",
        };
        db.Students.Add(student);
        var course = new Course()
        {
            CourseName = "Math",
            Instructor = instructor,
            CourseNumber = 101,
        };
        db.Courses.Add(course);
        db.Clazzes.Add(new Clazz()
        {
            Course = course,
            Section = section,
            NumRegistered = 45,
            ClazzDateTime = DateTime.Now,
        });
        db.StudentCourses.Add(new StudentCourse()
        {
            Course = course,
            Student = student,
        });
        db.SaveChanges();
        Console.WriteLine("Seeding complete");
    }
}