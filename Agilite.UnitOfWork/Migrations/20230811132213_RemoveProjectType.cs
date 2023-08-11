using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agilite.UnitOfWork.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProjectType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectTypes_FkProjectType",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Project_FkProjectType",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "FkProjectType",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FkProjectType",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Project_FkProjectType",
                table: "Project",
                column: "FkProjectType");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectTypes_FkProjectType",
                table: "Project",
                column: "FkProjectType",
                principalTable: "ProjectTypes",
                principalColumn: "IdProjectType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
