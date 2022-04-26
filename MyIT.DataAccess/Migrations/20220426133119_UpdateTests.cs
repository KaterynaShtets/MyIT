using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyIT.DataAccess.Migrations
{
    public partial class UpdateTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentUrl",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ResultPath",
                table: "AssignedStudentTests");

            migrationBuilder.AddColumn<string>(
                name: "ContentJson",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TestInterpretation",
                table: "AssignedStudentTests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ResultInterpretationJson",
                table: "AssignedStudentTests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultJson",
                table: "AssignedStudentTests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentJson",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "ResultInterpretationJson",
                table: "AssignedStudentTests");

            migrationBuilder.DropColumn(
                name: "ResultJson",
                table: "AssignedStudentTests");

            migrationBuilder.AddColumn<string>(
                name: "ContentUrl",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TestInterpretation",
                table: "AssignedStudentTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultPath",
                table: "AssignedStudentTests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
