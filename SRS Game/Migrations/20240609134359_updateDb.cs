using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SRS_Game.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Attachements_Name_Path_DocumentId",
                table: "Attachements");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attachements");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Attachements",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Attachements",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Attachements",
                newName: "CreateDate");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsExternal",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Attachements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Attachements",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileSourceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuthorId",
                table: "Documents",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_TeamLeaderId_VersionId",
                table: "Documents",
                columns: new[] { "Name", "TeamLeaderId", "VersionId" },
                unique: true,
                filter: "[TeamLeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TeamId",
                table: "Documents",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachements_FileName_DocumentId",
                table: "Attachements",
                columns: new[] { "FileName", "DocumentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_Id",
                table: "Files",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Name",
                table: "Projects",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Teams_TeamId",
                table: "Documents",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_AuthorId",
                table: "Documents",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachements_Documents_DocumentId",
                table: "Attachements",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Projects_ProjectId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Teams_TeamId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_AuthorId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AuthorId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_Name_TeamLeaderId_VersionId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TeamId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Attachements_FileName_DocumentId",
                table: "Attachements");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsExternal",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Attachements");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Attachements");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Attachements",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Attachements",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Attachements",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attachements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Name_TeamLeaderId_Version",
                table: "Documents",
                columns: new[] { "Name", "TeamLeaderId", "Version" },
                unique: true,
                filter: "[TeamLeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachements_Name_Path_DocumentId",
                table: "Attachements",
                columns: new[] { "Name", "Path", "DocumentId" },
                unique: true);
        }
    }
}
