namespace WebApiBackgroundServicesDbLib;

public class StudentCourse
{
    public int StudentCourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;
}