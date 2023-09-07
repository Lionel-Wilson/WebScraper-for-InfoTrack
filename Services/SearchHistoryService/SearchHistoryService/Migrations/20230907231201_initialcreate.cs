using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchHistoryService.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegexPattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchEngineId = table.Column<int>(type: "int", nullable: false),
                    Ranking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchHistories_SearchEngine_SearchEngineId",
                        column: x => x.SearchEngineId,
                        principalTable: "SearchEngine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistories_SearchEngineId",
                table: "SearchHistories",
                column: "SearchEngineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchHistories");

            migrationBuilder.DropTable(
                name: "SearchEngine");
        }
    }
}
