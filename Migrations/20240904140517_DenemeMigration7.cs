using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace erentitan.Migrations
{
    /// <inheritdoc />
    public partial class DenemeMigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classroom_Id",
                table: "ClassroomResponses");

            migrationBuilder.RenameColumn(
                name: "Course_Id",
                table: "ClassroomResponses",
                newName: "ClassId");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "ClassroomResponses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "ClassroomResponses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CourseStartDate",
                table: "ClassroomResponses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "ClassroomResponses");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "ClassroomResponses");

            migrationBuilder.DropColumn(
                name: "CourseStartDate",
                table: "ClassroomResponses");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "ClassroomResponses",
                newName: "Course_Id");

            migrationBuilder.AddColumn<long>(
                name: "Classroom_Id",
                table: "ClassroomResponses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
