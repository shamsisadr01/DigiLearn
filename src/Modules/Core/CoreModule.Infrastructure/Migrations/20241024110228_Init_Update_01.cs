using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init_Update_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canonical",
                schema: "course",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IndexPage",
                schema: "course",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "course",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MetaKeyWords",
                schema: "course",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "course",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Schema",
                schema: "course",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Canonical",
                schema: "course",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IndexPage",
                schema: "course",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "course",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeyWords",
                schema: "course",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "course",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Schema",
                schema: "course",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
