using erentitan.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.IO;
using Newtonsoft.Json;

namespace erentitan.Services;

public class seninicin
{
    public static void ahmetmaya()
    {
        AppDbContext db = new AppDbContext();
        //var b = db.Classrooms.ToList();
        //var c = db.Students.Where(l => l.Id == 31).Select(s => new Test {isim = s.Name}).ToList();
       // var anan = db.Students.FirstOrDefault(l => l.Id == 62);

       var studentquery =
           db.StudentsWithClassrooms
               .Join(db.Students, l => l.Student_Id, s => s.Id, (l, s) => new { l, s })
               .ToList();
       Console.WriteLine(JsonConvert.SerializeObject((studentquery)));
       var classroomquery =
           db.StudentsWithClassrooms
               .Join(db.Classrooms, a => a.Classroom_Id, b => b.Id, (a, b) => new { a, b })
               .ToList();

       








       //var resp = a.StudentsWithClassrooms.Where(l => l.Classroom_Id == classrom_id).ToList();



    }

    public static string dateInit()
    {
        string st = "";
        var db = new AppDbContext();
        foreach (var course in db.Courses)
        {
            st += course.StartDate.ToShortDateString();
            st += "\n";
            st += course.EndDate.ToShortDateString();
            st += "\n";
            st += "***************************";
            st += "\n";
        }

        return st;
    }
}