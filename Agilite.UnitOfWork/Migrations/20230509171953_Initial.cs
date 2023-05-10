using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    IdContact = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContact = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ArchivedContact = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.IdContact);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    IdMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextMessage = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.IdMessage);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTeam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberMembersTeam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.IdTeam);
                });

            migrationBuilder.CreateTable(
                name: "TeamRole",
                columns: table => new
                {
                    idTeamRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleTeamRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccessTeamRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRole", x => x.idTeamRole);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastNameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailUser = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PasswordUser = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EnumRoleUser = table.Column<int>(type: "int", nullable: false),
                    DateCreationUser = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    AgeUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team_IdTeam = table.Column<int>(type: "int", nullable: false),
                    NameProject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreationProject = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEnded = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.IdProject);
                    table.ForeignKey(
                        name: "fk_Project_Team1",
                        column: x => x.Team_IdTeam,
                        principalTable: "Team",
                        principalColumn: "IdTeam");
                });

            migrationBuilder.CreateTable(
                name: "Planning",
                columns: table => new
                {
                    idPlanning = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_IdUser = table.Column<int>(type: "int", nullable: false),
                    StartDatePlanning = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDatePlanning = table.Column<DateTime>(type: "datetime", nullable: false)
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
                        principalColumn: "IdContact");
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

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    IdSprint = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Project_IdProject = table.Column<int>(type: "int", nullable: false),
                    NumberSprint = table.Column<int>(type: "int", nullable: false),
                    StartDateSprint = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDateSprint = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.IdSprint);
                    table.ForeignKey(
                        name: "fk_Sprint_Project1",
                        column: x => x.Project_IdProject,
                        principalTable: "Project",
                        principalColumn: "IdProject");
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    IdObjective = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sprint_IdSprint = table.Column<int>(type: "int", nullable: false),
                    NameObjective = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberObjective = table.Column<int>(type: "int", nullable: false),
                    EnumTypeObjective = table.Column<int>(type: "int", nullable: false),
                    TextObjective = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.IdObjective);
                    table.ForeignKey(
                        name: "fk_Objective_Sprint1",
                        column: x => x.Sprint_IdSprint,
                        principalTable: "Sprint",
                        principalColumn: "IdSprint");
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    IdTask = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objective_IdObjective = table.Column<int>(type: "int", nullable: false),
                    NameTask = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NumberTask = table.Column<int>(type: "int", nullable: false),
                    EnumTypeTask = table.Column<int>(type: "int", nullable: false),
                    EnumStateTask = table.Column<int>(type: "int", nullable: false),
                    TextTask = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    StartLogTimeTask = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndLogTimeTask = table.Column<DateTime>(type: "datetime", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "fk_Objective_Sprint1_idx",
                table: "Objective",
                column: "Sprint_IdSprint");

            migrationBuilder.CreateIndex(
                name: "fk_Planning_User1_idx",
                table: "Planning",
                column: "User_IdUser");

            migrationBuilder.CreateIndex(
                name: "fk_Project_Team1_idx",
                table: "Project",
                column: "Team_IdTeam");

            migrationBuilder.CreateIndex(
                name: "fk_Sprint_Project1_idx",
                table: "Sprint",
                column: "Project_IdProject");

            migrationBuilder.CreateIndex(
                name: "fk_Task_Objective1_idx",
                table: "Task",
                column: "Objective_IdObjective");

            migrationBuilder.CreateIndex(
                name: "EmailUser_UNIQUE",
                table: "User",
                column: "EmailUser",
                unique: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planning");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "UserMessageContact");

            migrationBuilder.DropTable(
                name: "UserTeamTeamRole");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "TeamRole");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
