namespace erentitan.Models;

public class ClassroomResponse
{
    
    public static long idnum = 0;

    public ClassroomResponse(long classId, string className, string courseName)
    {
        ClassId = classId;
        ClassName = className;
        CourseName = courseName;
        idnum++;
        Id = idnum;
    }
    
    public long Id { get; set; }
    public long ClassId { get; set; }
    public string ClassName { get; set; }
    public string CourseName { get; set; }
    public DateTime CourseStartDate { get; set; }
     
    
}