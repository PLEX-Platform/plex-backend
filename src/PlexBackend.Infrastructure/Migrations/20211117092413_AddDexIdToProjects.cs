using Microsoft.EntityFrameworkCore.Migrations;

namespace PlexBackend.Infrastructure.Migrations
{
    public partial class AddDexIdToProjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DEXId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentChoices_ProjectId",
                table: "StudentChoices",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentChoices_Projects_ProjectId",
                table: "StudentChoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentChoices_Projects_ProjectId",
                table: "StudentChoices");

            migrationBuilder.DropIndex(
                name: "IX_StudentChoices_ProjectId",
                table: "StudentChoices");

            migrationBuilder.DropColumn(
                name: "DEXId",
                table: "Projects");
        }
    }
}
