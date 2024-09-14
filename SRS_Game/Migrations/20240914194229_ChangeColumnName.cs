using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocId",
                table: "DocumentHistories",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentHistories_DocId_AuthorId_Version",
                table: "DocumentHistories",
                newName: "IX_DocumentHistories_DocumentId_AuthorId_Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "DocumentHistories",
                newName: "DocId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentHistories_DocumentId_AuthorId_Version",
                table: "DocumentHistories",
                newName: "IX_DocumentHistories_DocId_AuthorId_Version");
        }
    }
}
