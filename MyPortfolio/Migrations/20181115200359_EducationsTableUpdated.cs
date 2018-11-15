using Microsoft.EntityFrameworkCore.Migrations;

namespace MyPortfolio.Migrations
{
    public partial class EducationsTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Educations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Educations",
                nullable: false,
                defaultValue: false);
        }
    }
}
