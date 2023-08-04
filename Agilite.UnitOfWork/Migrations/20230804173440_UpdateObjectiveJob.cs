using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class UpdateObjectiveJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobObjectives");

            migrationBuilder.CreateTable(
                name: "JobObjective",
                columns: table => new
                {
                    JobsIdJob = table.Column<int>(type: "int", nullable: false),
                    ObjectivesIdObjective = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobObjective", x => new { x.JobsIdJob, x.ObjectivesIdObjective });
                    table.ForeignKey(
                        name: "FK_JobObjective_Job_JobsIdJob",
                        column: x => x.JobsIdJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobObjective_Objective_ObjectivesIdObjective",
                        column: x => x.ObjectivesIdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobObjective_ObjectivesIdObjective",
                table: "JobObjective",
                column: "ObjectivesIdObjective");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobObjective");

            migrationBuilder.CreateTable(
                name: "JobObjectives",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "int", nullable: false),
                    IdObjective = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobObjectives", x => x.IdJob);
                    table.ForeignKey(
                        name: "FK_JobObjectives_Job_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Job",
                        principalColumn: "IdJob",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobObjectives_Objective_IdObjective",
                        column: x => x.IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobObjectives_IdObjective",
                table: "JobObjectives",
                column: "IdObjective");
        }
    }
}
