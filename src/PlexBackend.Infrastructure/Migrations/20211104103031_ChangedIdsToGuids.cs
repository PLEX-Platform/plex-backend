using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlexBackend.Infrastructure.Migrations
{
    public partial class ChangedIdsToGuids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentChoices",
                table: "StudentChoices");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentChoices");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentChoiceId",
                table: "StudentChoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentChoices",
                table: "StudentChoices",
                column: "StudentChoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentChoices",
                table: "StudentChoices");

            migrationBuilder.DropColumn(
                name: "StudentChoiceId",
                table: "StudentChoices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentChoices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentChoices",
                table: "StudentChoices",
                column: "Id");
        }
    }
}
