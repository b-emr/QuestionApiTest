using erentitan.Models;

namespace erentitan.Services;

public class GetStudentById
{
    public static string getName(long id)
    {
        var db = new AppDbContext();
        return db.Students.Find(id)?.Name; 
    }
}