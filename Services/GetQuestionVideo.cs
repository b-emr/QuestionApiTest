using erentitan.Models;

namespace erentitan.Services;

public class GetQuestionVideo
{
    public static string getImageUrl(AppDbContext db, int id)
    {
        return db.TestSectionElements.Find(id).ImageUrl;
    }
    
    public static string getImageWidth(AppDbContext db, int id)
    {
        return db.TestSectionElements.Find(id).ImageWidth;
    }
    
    public static string getImageHeight(AppDbContext db, int id)
    {
        return db.TestSectionElements.Find(id).ImageHeight;
    }
    
    public static string getXaml(AppDbContext db, int id)
    {
        return db.TestSectionElements.Find(id).Xaml;
    }
    
}