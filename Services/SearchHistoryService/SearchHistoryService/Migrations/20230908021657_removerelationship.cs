using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SearchHistoryService.Migrations
{
    /// <inheritdoc />
    public partial class removerelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SearchHistories_SearchEngine_SearchEngineId",
                table: "SearchHistories");

            migrationBuilder.DropTable(
                name: "SearchEngine");

            migrationBuilder.DropIndex(
                name: "IX_SearchHistories_SearchEngineId",
                table: "SearchHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchEngine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeaderValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegexPattern = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchEngine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistories_SearchEngineId",
                table: "SearchHistories",
                column: "SearchEngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_SearchHistories_SearchEngine_SearchEngineId",
                table: "SearchHistories",
                column: "SearchEngineId",
                principalTable: "SearchEngine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
