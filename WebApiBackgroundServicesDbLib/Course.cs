namespace WebApiBackgroundServicesDbLib;

public class Course
{
    public int CourseId { get; set; }
    public int CourseNumber { get; set; }
    public string CourseName { get; set; } = null!;
    public List<StudentCourse> StudentCourses { get; set; } = null!;
    public List<Clazz> Clazzes { get; set; } = null!;
    public Instructor Instructor { get; set; } = null!;
}