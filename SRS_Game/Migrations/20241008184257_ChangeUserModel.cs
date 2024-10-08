using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleFK",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "UserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserRole",
                table: "UserRoles",
                column: "UserRole");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserRole",
                table: "UserRoles",
                column: "UserRole",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserRole",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserRole",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "UserRoles");

            migrationBuilder.AddColumn<int>(
                name: "UserRoleFK",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
