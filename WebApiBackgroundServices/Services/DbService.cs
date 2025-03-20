using Microsoft.EntityFrameworkCore;
using WebApiBackgroundServices.Models.Dtos;
using WebApiBackgroundServicesDbLib;

namespace WebApiBackgroundServices.Services;

public class DbService(ApiContext db)
{
    public List<Course> GetAllCourses()
    {
        return db.Courses
            .Include(x=>x.Instructor)
            .Include(x=>x.Clazzes)
            .Include(x=>x.StudentCourses)
            .ToList();
    }

    public Course GetCourse(int id)
    {
        return db.Courses
            .Where(course => course.CourseId == id)
            .Include(x => x.Instructor)
            .Include(x => x.Clazzes)
            .Include(x => x.StudentCourses)
            .Single();
    }

    public void AddStudentToCourse(int courseId, int studentId)
    {
        var studentCourse = new StudentCourse()
        {
            Course = db.Courses.Single(course => course.CourseId == courseId),
            Student = db.Students.Single(student => student.StudentId == studentId),
        };
        db.StudentCourses.Add(studentCourse);
        db.SaveChanges();
    }

    public void DeleteCourse(int courseId)
    {
        var course = db.Courses.Single(course => course.CourseId == courseId);
        db.Courses.Remove(course);
        db.SaveChanges();
    }

    public List<Student> GetStudentsWithName(string name)
    {
        return db.Students
            .Where(student => student.StudentName.ToLower().Contains(name.ToLower()))
            .ToList();
    }

    public List<Student> GetStudentsWithAddress(string s)
    {
        return db.Students
            .Where(student => student.StudentAddress.ToLower().Contains(s.ToLower()))
            .ToList();
    }

    public List<Instructor> GetAllInstructors()
    {
        return db.Instructors.ToList();
    }

    public List<Section> GetAllSections()
    {
        return db.Sections.ToList();
    }

    public List<Clazz> GetFilteredClazzes(int? courseNumber, int? sectionNumber)
    {
        var query = db.Clazzes
            .Include(clazz => clazz.Course).AsQueryable();
        if (courseNumber != null)
        {
            query = query.Where(clazz => clazz.Course.CourseNumber == courseNumber);
        }
        if (sectionNumber != null)
        {
            query = query.Where(clazz => clazz.Section.SectionId == sectionNumber);
        }
        return query.ToList();
    }
}