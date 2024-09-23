using Microsoft.EntityFrameworkCore;

namespace erentitan.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public AppDbContext()
    {
        
    }

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Classroom> Classrooms { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
 
    public DbSet<StudentResponse> StudentResponses { get; set; } = null!;
    
    public DbSet<ClassroomResponse> ClassroomResponses { get; set; } = null!;
    
    public DbSet<StudentsWithClassrooms> StudentsWithClassrooms { get; set; } = null!;
    
    public DbSet<ClassroomsWithCourses> ClassroomsWithCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("Default");
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
    

}

