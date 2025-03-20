using Microsoft.AspNetCore.Mvc;
using WebApiBackgroundServices.Models.Dtos;
using WebApiBackgroundServices.Services;
using WebApiCodeFirst_325;

namespace WebApiBackgroundServices.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentsController(DbService service) : ControllerBase
{
    [HttpGet]
    public List<StudentDto> GetStudentsNameFilter(string name)
    {
        return service.GetStudentsWithName(name)
            .Select(student => new StudentDto().CopyFrom(student))
            .ToList();
    }
    [HttpGet("/StudentsByAddress")]
    public List<StudentDto> GetStudentsAddressFilter(string q)
    {
        return service.GetStudentsWithAddress(q)
            .Select(student => new StudentDto().CopyFrom(student))
            .ToList();
    }
}