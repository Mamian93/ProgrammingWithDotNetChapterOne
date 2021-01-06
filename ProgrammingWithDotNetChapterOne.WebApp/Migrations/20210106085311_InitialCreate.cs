using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProgrammingWithDotNetChapterOne.WebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityId = table.Column<int>(nullable: false),
                    ModuleName1 = table.Column<string>(nullable: true),
                    ModuleName2 = table.Column<string>(nullable: true),
                    ModuleName3 = table.Column<string>(nullable: true),
                    ModuleName4 = table.Column<string>(nullable: true),
                    ProductionCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    TransportCost = table.Column<double>(nullable: false),
                    CostOfWorkingHour = table.Column<double>(nullable: false),
                    SearchHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_SearchHistory_SearchHistoryId",
                        column: x => x.SearchHistoryId,
                        principalTable: "SearchHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AssemblyTime = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SearchHistoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Module_SearchHistory_SearchHistoryId",
                        column: x => x.SearchHistoryId,
                        principalTable: "SearchHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_SearchHistoryId",
                table: "City",
                column: "SearchHistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Module_SearchHistoryId",
                table: "Module",
                column: "SearchHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "SearchHistory");
        }
    }
}
