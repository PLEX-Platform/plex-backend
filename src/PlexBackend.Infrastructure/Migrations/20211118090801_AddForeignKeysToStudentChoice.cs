using Microsoft.EntityFrameworkCore.Migrations;

namespace PlexBackend.Infrastructure.Migrations
{
    public partial class AddForeignKeysToStudentChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "StudentChoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentNumber",
                table: "Students",
                column: "StudentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentChoices_ProjectId",
                table: "StudentChoices",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentChoices_StudentId",
                table: "StudentChoices",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DEXId",
                table: "Projects",
                column: "DEXId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentChoices_Projects_ProjectId",
                table: "StudentChoices",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentChoices_Students_StudentId",
                table: "StudentChoices",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentChoices_Projects_ProjectId",
                table: "StudentChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentChoices_Students_StudentId",
                table: "StudentChoices");

            migrationBuilder.DropIndex(
                name: "IX_Students_StudentNumber",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentChoices_ProjectId",
                table: "StudentChoices");

            migrationBuilder.DropIndex(
                name: "IX_StudentChoices_StudentId",
                table: "StudentChoices");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DEXId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentChoices");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Students",
                newName: "Name");
        }
    }
}
