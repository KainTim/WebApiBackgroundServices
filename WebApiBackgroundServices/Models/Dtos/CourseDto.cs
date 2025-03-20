using WebApiBackgroundServicesDbLib;

namespace WebApiBackgroundServices.Models.Dtos;

public class CourseDto
{
    public int CourseId { get; set; }
    public int CourseNumber { get; set; }
    public string CourseName { get; set; } = null!;
    public int NrClazzes { get; set; }
    public int NrStudents { get; set; }
    public string InstructorName { get; set; } = null!;
}