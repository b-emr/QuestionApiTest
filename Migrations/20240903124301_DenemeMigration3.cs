using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace erentitan.Migrations
{
    /// <inheritdoc />
    public partial class DenemeMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Student_Id",
                table: "ClassroomsWithCourses",
                newName: "Course_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Course_Id",
                table: "ClassroomsWithCourses",
                newName: "Student_Id");
        }
    }
}
