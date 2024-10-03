using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Users",
                newName: "UserRoleFK");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TeamLeaderId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents",
                columns: new[] { "Name", "TeamLeaderId", "Version" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "UserRoleFK",
                table: "Users",
                newName: "RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamLeaderId",
                table: "Documents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents",
                columns: new[] { "Name", "TeamLeaderId", "Version" },
                unique: true,
                filter: "[TeamLeaderId] IS NOT NULL");
        }
    }
}
