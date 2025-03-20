using Microsoft.AspNetCore.Mvc;
using WebApiBackgroundServicesDbLib;

namespace WebApiBackgroundServices.Controllers;

[ApiController]
[Route("[controller]")]
public class DbTestController(ApiContext db) : ControllerBase
{

    [HttpGet("GetCourseCount")]
    public int GetCourseCount()
    {
        return db.Courses.Count();
    }
}