using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Introduction",
                table: "Documents",
                newName: "Destination");

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "Documents",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Documents",
                newName: "Introduction");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
