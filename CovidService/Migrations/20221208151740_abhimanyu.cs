using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidService.Migrations
{
    public partial class abhimanyu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SampleTables");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SampleTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTables", x => x.Id);
                });
        }
    }
}
