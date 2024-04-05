using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillProfiWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UISettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainSettings",
                columns: table => new
                {
                    LayoutHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactsHeader = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainSettings");
        }
    }
}
