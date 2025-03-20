namespace WebApiBackgroundServicesDbLib;

public class Clazz
{
    public int ClazzId { get; set; }
    public int NumRegistered { get; set; }
    public DateTime ClazzDateTime { get; set; }
    public Section Section { get; set; } = null!;
    public Course Course { get; set; } = null!;
}