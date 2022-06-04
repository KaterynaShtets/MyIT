using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyIT.DataAccess.Migrations
{
    public partial class UpdatePs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isVerified",
                table: "Psychologists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isVerified",
                table: "Psychologists");
        }
    }
}
