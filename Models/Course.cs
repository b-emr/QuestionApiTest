namespace erentitan.Models;

public class Course
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public DateTime StartDate {get; set; }
    public DateTime EndDate {get; set; }
    
}