using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobState",
                columns: table => new
                {
                    IdJobState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameJobState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobState", x => x.IdJobState);
                });

            migrationBuilder.CreateTable(
                name: "ObjectiveTypes",
                columns: table => new
                {
                    IdObjectiveType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameObjectiveType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectiveTypes", x => x.IdObjectiveType);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    IdProjectType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProjectType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.IdProjectType);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTeam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfMembersTeam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastNameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SaltUser = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreationUser = table.Column<DateTime>(type: "datetime", nullable: false),
                    AgeUser = table.Column<int>(type: "int", nullable: false),
                    ArchivedUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkJobSate = table.Column<int>(type: "int", nullable: false),
                    NameJob = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberJob = table.Column<int>(type: "int", nullable: false),
                    TextJob = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    StartLogTimeJob = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndLogTimeJob = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.IdJob);
                    table.ForeignKey(
                        name: "FK_Job_JobState_FkJobSate",
                        column: x => x.FkJobSate,
                        principalTable: "JobState",
                        principalColumn: "IdJobState",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    IdObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkObjectiveType = table.Column<int>(type: "int", nullable: false),
                    NameObjective = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberObjective = table.Column<int>(type: "int", nullable: false),
                    TextObjective = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.IdObjective);
                    table.ForeignKey(
                        name: "FK_Objective_ObjectiveTypes_FkObjectiveType",
                        column: x => x.FkObjectiveType,
                        principalTable: "ObjectiveTypes",
                        principalColumn: "IdObjectiveType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkTeam = table.Column<int>(type: "int", nullable: false),
                    FkProjectType = table.Column<int>(type: "int", nullable: false),
                    NameProject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreationProject = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEndedProject = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.IdProject);
                    table.ForeignKey(
                        name: "FK_Project_ProjectTypes_FkProjectType",
                        column: x => x.FkProjectType,
                        principalTable: "ProjectTypes",
                        principalColumn: "IdProjectType",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Team_FkTeam",
                        column: x => x.FkTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    IdMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkReceiverUser = table.Column<int>(type: "int", nullable: false),
                    FkSenderUser = table.Column<int>(type: "int", nullable: false),
                    TextMessage = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    ArchivedMessage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.IdMessage);
                    table.ForeignKey(
                        name: "FK_Message_User_FkSenderUser",
                        column: x => x.FkSenderUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamUser",
                columns: table => new
                {
                    TeamsIdTeam = table.Column<int>(type: "int", nullable: false),
                    UsersIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamUser", x => new { x.TeamsIdTeam, x.UsersIdUser });
                    table.ForeignKey(
                        name: "FK_TeamUser_Team_TeamsIdTeam",
                        column: x => x.TeamsIdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamUser_User_UsersIdUser",
                        column: x => x.UsersIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    IdSprint = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkProject = table.Column<int>(type: "int", nullable: false),
                    NumberSprint = table.Column<int>(type: "int", nullable: false),
                    StartDateSprint = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDateSprint = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.IdSprint);
                    table.ForeignKey(
                        name: "FK_Sprint_Project_FkProject",
                        column: x => x.FkProject,
                        principalTable: "Project",
                        principalColumn: "IdProject",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Job_FkJobSate",
                table: "Job",
                column: "FkJobSate");

            migrationBuilder.CreateIndex(
                name: "IX_JobObjectives_IdObjective",
                table: "JobObjectives",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FkSenderUser",
                table: "Message",
                column: "FkSenderUser");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_FkObjectiveType",
                table: "Objective",
                column: "FkObjectiveType");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FkProjectType",
                table: "Project",
                column: "FkProjectType");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FkTeam",
                table: "Project",
                column: "FkTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_FkProject",
                table: "Sprint",
                column: "FkProject");

            migrationBuilder.CreateIndex(
                name: "IX_SprintObjectives_IdObjective",
                table: "SprintObjectives",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUser_UsersIdUser",
                table: "TeamUser",
                column: "UsersIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailUser",
                table: "User",
                column: "EmailUser",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobObjectives");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "SprintObjectives");

            migrationBuilder.DropTable(
                name: "TeamUser");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "JobState");

            migrationBuilder.DropTable(
                name: "ObjectiveTypes");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
