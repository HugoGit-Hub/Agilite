using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDataBaseStrcuture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_Objective_Sprint1",
                table: "Objective");

            migrationBuilder.DropForeignKey(
                name: "fk_Project_Team1",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "fk_Sprint_Project1",
                table: "Sprint");

            migrationBuilder.DropTable(
                name: "Planning");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "UserMessageContact");

            migrationBuilder.DropTable(
                name: "UserTeamTeamRole");

            migrationBuilder.DropTable(
                name: "TeamRole");

            migrationBuilder.DropIndex(
                name: "EmailUser_UNIQUE",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EnumRoleUser",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EnumTypeObjective",
                table: "Objective");

            migrationBuilder.RenameColumn(
                name: "Project_IdProject",
                table: "Sprint",
                newName: "FkProject");

            migrationBuilder.RenameIndex(
                name: "fk_Sprint_Project1_idx",
                table: "Sprint",
                newName: "IX_Sprint_FkProject");

            migrationBuilder.RenameColumn(
                name: "Team_IdTeam",
                table: "Project",
                newName: "FkTeam");

            migrationBuilder.RenameIndex(
                name: "fk_Project_Team1_idx",
                table: "Project",
                newName: "IX_Project_FkTeam");

            migrationBuilder.RenameColumn(
                name: "Sprint_IdSprint",
                table: "Objective",
                newName: "FkObjectiveType");

            migrationBuilder.RenameIndex(
                name: "fk_Objective_Sprint1_idx",
                table: "Objective",
                newName: "IX_Objective_FkObjectiveType");

            //migrationBuilder.RenameColumn(
            //    name: "FkContact",
            //    table: "Contact",
            //    newName: "IdContact");

            migrationBuilder.RenameColumn(
                name:"DateEnded",
                table:"Project",
                newName:"DateEndedProject");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreationUser",
                table: "User",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<int>(
                name: "AgeUser",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ArchivedUser",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateEndedProject",
                table: "Project",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FkProjectType",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ArchivedMessage",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FkContact",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "ArchivedContact",
                table: "Contact",
                type: "bit",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

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

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdContact = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_UserContacts_Contact_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contact",
                        principalColumn: "IdContact",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserContacts_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdTeam = table.Column<int>(type: "int", nullable: false),
                    RoleUserTeam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_UserTeams_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTeams_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Project_FkProjectType",
                table: "Project",
                column: "FkProjectType");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FkContact",
                table: "Message",
                column: "FkContact");

            migrationBuilder.CreateIndex(
                name: "IX_Job_FkJobSate",
                table: "Job",
                column: "FkJobSate");

            migrationBuilder.CreateIndex(
                name: "IX_JobObjectives_IdObjective",
                table: "JobObjectives",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_SprintObjectives_IdObjective",
                table: "SprintObjectives",
                column: "IdObjective");

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_IdContact",
                table: "UserContacts",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_IdTeam",
                table: "UserTeams",
                column: "IdTeam");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Contact_FkContact",
                table: "Message",
                column: "FkContact",
                principalTable: "Contact",
                principalColumn: "IdContact",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Objective_ObjectiveTypes_FkObjectiveType",
                table: "Objective",
                column: "FkObjectiveType",
                principalTable: "ObjectiveTypes",
                principalColumn: "IdObjectiveType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectTypes_FkProjectType",
                table: "Project",
                column: "FkProjectType",
                principalTable: "ProjectTypes",
                principalColumn: "IdProjectType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Team_FkTeam",
                table: "Project",
                column: "FkTeam",
                principalTable: "Team",
                principalColumn: "IdTeam",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_Project_FkProject",
                table: "Sprint",
                column: "FkProject",
                principalTable: "Project",
                principalColumn: "IdProject",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Contact_FkContact",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Objective_ObjectiveTypes_FkObjectiveType",
                table: "Objective");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectTypes_FkProjectType",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Team_FkTeam",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_Project_FkProject",
                table: "Sprint");

            migrationBuilder.DropTable(
                name: "JobObjectives");

            migrationBuilder.DropTable(
                name: "ObjectiveTypes");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "SprintObjectives");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "UserTeams");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "JobState");

            migrationBuilder.DropIndex(
                name: "IX_Project_FkProjectType",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Message_FkContact",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "ArchivedUser",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FkProjectType",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ArchivedMessage",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "FkContact",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "FkProject",
                table: "Sprint",
                newName: "Project_IdProject");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_FkProject",
                table: "Sprint",
                newName: "fk_Sprint_Project1_idx");

            migrationBuilder.RenameColumn(
                name: "FkTeam",
                table: "Project",
                newName: "Team_IdTeam");

            migrationBuilder.RenameIndex(
                name: "IX_Project_FkTeam",
                table: "Project",
                newName: "fk_Project_Team1_idx");

            migrationBuilder.RenameColumn(
                name: "FkObjectiveType",
                table: "Objective",
                newName: "Sprint_IdSprint");

            migrationBuilder.RenameIndex(
                name: "IX_Objective_FkObjectiveType",
                table: "Objective",
                newName: "fk_Objective_Sprint1_idx");

            migrationBuilder.RenameColumn(
                name: "IdContact",
                table: "Contact",
                newName: "FkContact");

            migrationBuilder.AlterColumn<string>(
                name: "DateCreationUser",
                table: "User",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "AgeUser",
                table: "User",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EnumRoleUser",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "DateEndedProject",
                table: "Project",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<int>(
                name: "EnumTypeObjective",
                table: "Objective",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<short>(
                name: "ArchivedContact",
                table: "Contact",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "Planning",
                columns: table => new
                {
                    idPlanning = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_IdUser = table.Column<int>(type: "int", nullable: false),
                    EndDatePlanning = table.Column<DateTime>(type: "datetime", nullable: false),
                    StartDatePlanning = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planning", x => x.idPlanning);
                    table.ForeignKey(
                        name: "fk_Planning_User1",
                        column: x => x.User_IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objective_IdObjective = table.Column<int>(type: "int", nullable: false),
                    EndLogTimeTask = table.Column<DateTime>(type: "datetime", nullable: true),
                    EnumStateTask = table.Column<int>(type: "int", nullable: false),
                    EnumTypeTask = table.Column<int>(type: "int", nullable: false),
                    NameTask = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberTask = table.Column<int>(type: "int", nullable: false),
                    StartLogTimeTask = table.Column<DateTime>(type: "datetime", nullable: true),
                    TextTask = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.IdTask);
                    table.ForeignKey(
                        name: "fk_Task_Objective1",
                        column: x => x.Objective_IdObjective,
                        principalTable: "Objective",
                        principalColumn: "IdObjective");
                });

            migrationBuilder.CreateTable(
                name: "TeamRole",
                columns: table => new
                {
                    idTeamRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessTeamRole = table.Column<int>(type: "int", nullable: false),
                    TitleTeamRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRole", x => x.idTeamRole);
                });

            migrationBuilder.CreateTable(
                name: "UserMessageContact",
                columns: table => new
                {
                    User_IdUser = table.Column<int>(type: "int", nullable: false),
                    Contact_IdContact = table.Column<int>(type: "int", nullable: false),
                    Message_IdMessage = table.Column<int>(type: "int", nullable: false),
                    DateTimeUserMessageContact = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMessageContact", x => new { x.User_IdUser, x.Contact_IdContact, x.Message_IdMessage });
                    table.ForeignKey(
                        name: "fk_User_has_Contact_Contact1",
                        column: x => x.Contact_IdContact,
                        principalTable: "Contact",
                        principalColumn: "FkContact");
                    table.ForeignKey(
                        name: "fk_User_has_Contact_Message1",
                        column: x => x.Message_IdMessage,
                        principalTable: "Message",
                        principalColumn: "IdMessage");
                    table.ForeignKey(
                        name: "fk_User_has_Contact_User",
                        column: x => x.User_IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "UserTeamTeamRole",
                columns: table => new
                {
                    User_IdUser = table.Column<int>(type: "int", nullable: false),
                    Team_IdTeam = table.Column<int>(type: "int", nullable: false),
                    TeamRole_idTeamRole = table.Column<int>(type: "int", nullable: false),
                    DateTimeUserTeamTeamRole = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeamTeamRole", x => new { x.User_IdUser, x.Team_IdTeam, x.TeamRole_idTeamRole });
                    table.ForeignKey(
                        name: "fk_User_has_Team_Team1",
                        column: x => x.Team_IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam");
                    table.ForeignKey(
                        name: "fk_User_has_Team_TeamRole1",
                        column: x => x.TeamRole_idTeamRole,
                        principalTable: "TeamRole",
                        principalColumn: "idTeamRole");
                    table.ForeignKey(
                        name: "fk_User_has_Team_User1",
                        column: x => x.User_IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "EmailUser_UNIQUE",
                table: "User",
                column: "EmailUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Planning_User1_idx",
                table: "Planning",
                column: "User_IdUser");

            migrationBuilder.CreateIndex(
                name: "fk_Task_Objective1_idx",
                table: "Task",
                column: "Objective_IdObjective");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Contact_Contact1_idx",
                table: "UserMessageContact",
                column: "Contact_IdContact");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Contact_Message1_idx",
                table: "UserMessageContact",
                column: "Message_IdMessage");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Contact_User_idx",
                table: "UserMessageContact",
                column: "User_IdUser");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Team_Team1_idx",
                table: "UserTeamTeamRole",
                column: "Team_IdTeam");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Team_TeamRole1_idx",
                table: "UserTeamTeamRole",
                column: "TeamRole_idTeamRole");

            migrationBuilder.CreateIndex(
                name: "fk_User_has_Team_User1_idx",
                table: "UserTeamTeamRole",
                column: "User_IdUser");

            migrationBuilder.AddForeignKey(
                name: "fk_Objective_Sprint1",
                table: "Objective",
                column: "Sprint_IdSprint",
                principalTable: "Sprint",
                principalColumn: "IdSprint");

            migrationBuilder.AddForeignKey(
                name: "fk_Project_Team1",
                table: "Project",
                column: "Team_IdTeam",
                principalTable: "Team",
                principalColumn: "IdTeam");

            migrationBuilder.AddForeignKey(
                name: "fk_Sprint_Project1",
                table: "Sprint",
                column: "Project_IdProject",
                principalTable: "Project",
                principalColumn: "IdProject");
        }
    }
}
