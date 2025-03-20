using Microsoft.AspNetCore.Mvc;
using WebApiBackgroundServices.Models.Dtos;
using WebApiBackgroundServices.Services;
using WebApiCodeFirst_325;

namespace WebApiBackgroundServices.Controllers;
[ApiController]
[Route("[controller]")]
public class OtherController(DbService service) : ControllerBase
{
    [HttpGet("/Instructors")]
    public List<InstructorDto> GetAllInstructors()
    {
        return service.GetAllInstructors()
            .Select(instructor => new InstructorDto().CopyFrom(instructor))
            .ToList();
    }
    [HttpGet("/Sections")]
    public List<SectionDto> GetAllSections()
    {
        return service.GetAllSections()
            .Select(section => new SectionDto().CopyFrom(section))
            .ToList();
    }
    [HttpGet("/Clazzes")]
    public List<ClazzDto> GetAllClazzes(int? courseNumber, int? sectionNumber)
    {
        return service.GetFilteredClazzes(courseNumber, sectionNumber)
            .Select(clazz => new ClazzDto()
            {
                CourseName = clazz.Course.CourseName,
            }.CopyFrom(clazz))
            .ToList();
    }
}