using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Sections_SectionCourseId_SectionId",
                schema: "course",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                schema: "course",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                schema: "course",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "SectionCourseId",
                schema: "course",
                table: "Episodes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                schema: "course",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                schema: "course",
                table: "Episodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseId",
                schema: "course",
                table: "Sections",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SectionId",
                schema: "course",
                table: "Episodes",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Sections_SectionId",
                schema: "course",
                table: "Episodes",
                column: "SectionId",
                principalSchema: "course",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Sections_SectionId",
                schema: "course",
                table: "Episodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                schema: "course",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_CourseId",
                schema: "course",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Episodes",
                schema: "course",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_SectionId",
                schema: "course",
                table: "Episodes");

            migrationBuilder.AddColumn<Guid>(
                name: "SectionCourseId",
                schema: "course",
                table: "Episodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                schema: "course",
                table: "Sections",
                columns: new[] { "CourseId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Episodes",
                schema: "course",
                table: "Episodes",
                columns: new[] { "SectionCourseId", "SectionId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Sections_SectionCourseId_SectionId",
                schema: "course",
                table: "Episodes",
                columns: new[] { "SectionCourseId", "SectionId" },
                principalSchema: "course",
                principalTable: "Sections",
                principalColumns: new[] { "CourseId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
