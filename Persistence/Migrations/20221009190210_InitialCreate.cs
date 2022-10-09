using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SCBs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    County = table.Column<string>(type: "TEXT", nullable: true),
                    ManInCounty = table.Column<int>(type: "INTEGER", nullable: false),
                    WomanInCounty = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthYearOfBabies = table.Column<string>(type: "TEXT", nullable: true),
                    BabesTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCBs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCBs");
        }
    }
}
