using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSprintObjective : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SprintObjectives");

            migrationBuilder.CreateTable(
                name: "ObjectiveSprint",
                columns: table => new
                {
                    ObjectivesIdObjective = table.Column<int>(type: "int", nullable: false),
                    SprintsIdSprint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveSprint", x => new { x.ObjectivesIdObjective, x.SprintsIdSprint });
                    table.ForeignKey(
                        name: "FK_ObjectiveSprint_Objective_ObjectivesIdObjective",
                        column: x => x.ObjectivesIdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectiveSprint_Sprint_SprintsIdSprint",
                        column: x => x.SprintsIdSprint,
                        principalTable: "Sprint",
                        principalColumn: "IdSprint",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectiveSprint_SprintsIdSprint",
                table: "ObjectiveSprint",
                column: "SprintsIdSprint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectiveSprint");

            migrationBuilder.CreateTable(
                name: "SprintObjectives",
                columns: table => new
                {
                    IdSprint = table.Column<int>(type: "int", nullable: false),
                    IdObjective = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintObjectives", x => x.IdSprint);
                    table.ForeignKey(
                        name: "FK_SprintObjectives_Objective_IdObjective",
                        column: x => x.IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SprintObjectives_Sprint_IdSprint",
                        column: x => x.IdSprint,
                        principalTable: "Sprint",
                        principalColumn: "IdSprint",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SprintObjectives_IdObjective",
                table: "SprintObjectives",
                column: "IdObjective");
        }
    }
}
