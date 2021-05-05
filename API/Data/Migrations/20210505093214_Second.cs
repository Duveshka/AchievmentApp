using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "File",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_DocumentId",
                table: "File",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_File_File_DocumentId",
                table: "File",
                column: "DocumentId",
                principalTable: "File",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_File_File_DocumentId",
                table: "File");

            migrationBuilder.DropIndex(
                name: "IX_File_DocumentId",
                table: "File");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "File");
        }
    }
}
