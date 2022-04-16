using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyIT.DataAccess.Migrations
{
    public partial class UpdateSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Sessions");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "SessionComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "SessionComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "SessionComments");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Sessions",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "SessionComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
