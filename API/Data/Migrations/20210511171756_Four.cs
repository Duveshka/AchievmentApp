using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievment_AchievmentType_AchievmentTypeId",
                table: "Achievment");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "AchievmentTypeId",
                table: "Achievment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievment_AchievmentType_AchievmentTypeId",
                table: "Achievment",
                column: "AchievmentTypeId",
                principalTable: "AchievmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievment_AchievmentType_AchievmentTypeId",
                table: "Achievment");

            migrationBuilder.AlterColumn<int>(
                name: "Sex",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AchievmentTypeId",
                table: "Achievment",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievment_AchievmentType_AchievmentTypeId",
                table: "Achievment",
                column: "AchievmentTypeId",
                principalTable: "AchievmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
