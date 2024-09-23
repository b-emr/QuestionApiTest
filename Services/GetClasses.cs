using erentitan.Controllers;
using erentitan.Models;
using Microsoft.AspNetCore.Mvc;

namespace erentitan.Services;

public class GetClasses
{
    public static List<ClassroomResponse> getClass(AppDbContext db)
    {
        List<ClassroomResponse> classrooms = new List<ClassroomResponse>();
        int i = 0;
        var dt = DateTime.Now;
        string result = "";
        var items = db.ClassroomsWithCourses.Join(db.Courses, l => l.Course_Id, s => s.Id, (l, c) => new { l, c })
            .Where(x => x.c.EndDate > dt)
            .Join(db.Classrooms, a => a.l.Classroom_Id, b => b.Id, (a, b) => new { a, b })
            .ToList();
        foreach (var item in items)
        {
            ClassroomResponse newClass = new ClassroomResponse(item.b.Id, item.b.Name, item.a.c.Name);
            newClass.CourseStartDate = item.a.c.StartDate;
            i++;
            classrooms.Add(newClass);
        }

        return classrooms;
    }
}