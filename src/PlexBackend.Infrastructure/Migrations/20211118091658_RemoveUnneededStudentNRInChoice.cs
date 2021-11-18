using Microsoft.EntityFrameworkCore.Migrations;

namespace PlexBackend.Infrastructure.Migrations
{
    public partial class RemoveUnneededStudentNRInChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentPCN",
                table: "StudentChoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentPCN",
                table: "StudentChoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
