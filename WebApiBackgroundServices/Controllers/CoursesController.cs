using Microsoft.AspNetCore.Mvc;
using WebApiBackgroundServices.Models.Dtos;
using WebApiBackgroundServices.Services;
using WebApiCodeFirst_325;

namespace WebApiBackgroundServices.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController(DbService service) : ControllerBase
{
    [HttpGet]
    public List<CourseDto> GetAllCourses()
    {
        return service.GetAllCourses()
            .Select(course => new CourseDto()
            {
                InstructorName = course.Instructor.InstructorName,
                NrClazzes = course.Clazzes.Count,
                NrStudents = course.StudentCourses.Count,
            }.CopyFrom(course))
            .ToList();
    }
    [HttpGet("{id:int}")]
    public CourseDto GetAllCourses(int id)
    {
        var course = service.GetCourse(id);
        return new CourseDto()
        {
            InstructorName = course.Instructor.InstructorName,
            NrClazzes = course.Clazzes.Count,
            NrStudents = course.StudentCourses.Count,
        }.CopyFrom(course);
    }

    [HttpPost("{courseId:int}")]
    public void AddStudentToCourse(int courseId, int studentId)
    {
        service.AddStudentToCourse(courseId, studentId);
    }
    [HttpDelete("{courseId:int}")]
    public void DeleteCourse(int courseId)
    {
        service.DeleteCourse(courseId);
    }
}