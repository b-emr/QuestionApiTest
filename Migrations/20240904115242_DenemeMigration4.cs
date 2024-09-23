using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace erentitan.Migrations
{
    /// <inheritdoc />
    public partial class DenemeMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentResponses",
                newName: "StudentName");

            migrationBuilder.AddColumn<string>(
                name: "ClassroomName",
                table: "StudentResponses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassroomName",
                table: "StudentResponses");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "StudentResponses",
                newName: "Name");
        }
    }
}
