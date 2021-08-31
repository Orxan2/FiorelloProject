using Microsoft.EntityFrameworkCore.Migrations;

namespace FiorelloProject.Migrations
{
    public partial class UpdateExpertsAndProfessionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professions_Experts_ExpertId",
                table: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Professions_ExpertId",
                table: "Professions");

            migrationBuilder.DropColumn(
                name: "ExpertId",
                table: "Professions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpertId",
                table: "Professions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professions_ExpertId",
                table: "Professions",
                column: "ExpertId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professions_Experts_ExpertId",
                table: "Professions",
                column: "ExpertId",
                principalTable: "Experts",
                principalColumn: "ExpertId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
