namespace WebApiBackgroundServices.Models.Dtos;

public class StudentDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public string StudentAddress { get; set; } = null!;
}