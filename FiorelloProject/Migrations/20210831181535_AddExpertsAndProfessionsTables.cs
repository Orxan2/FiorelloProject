using Microsoft.EntityFrameworkCore.Migrations;

namespace FiorelloProject.Migrations
{
    public partial class AddExpertsAndProfessionsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ExpertId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    ExpertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(nullable: true),
                    ProfessionId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.ExpertId);
                    table.ForeignKey(
                        name: "FK_Experts_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ProfessionId",
                table: "Experts",
                column: "ProfessionId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experts_Professions_ProfessionId",
                table: "Experts");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "Experts");
        }
    }
}
