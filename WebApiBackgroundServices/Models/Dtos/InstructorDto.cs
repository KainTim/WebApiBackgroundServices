namespace WebApiBackgroundServices.Models.Dtos;

public class InstructorDto
{
    public int InstructorId { get; set; }
    public string InstructorName { get; set; } = null!;
    public string InstructorFaculty { get; set; } = null!;
}