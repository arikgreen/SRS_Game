using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameDocuments_Version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VersionId",
                table: "Documents",
                newName: "Version");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_Name_TeamLeaderId_VersionId",
                table: "Documents",
                newName: "IX_Documents_Name_TeamLeaderId_Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Documents",
                newName: "VersionId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents",
                newName: "IX_Documents_Name_TeamLeaderId_VersionId");
        }
    }
}
