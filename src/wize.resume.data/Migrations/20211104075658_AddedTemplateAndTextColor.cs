using Microsoft.EntityFrameworkCore.Migrations;

namespace wize.resume.data.Migrations
{
    public partial class AddedTemplateAndTextColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccentTextColor",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Template",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccentTextColor",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "Template",
                table: "Resumes");
        }
    }
}
