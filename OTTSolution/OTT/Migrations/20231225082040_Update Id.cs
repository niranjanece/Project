using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTT.Migrations
{
    public partial class UpdateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "WatchHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WatchHistories_MovieId",
                table: "WatchHistories",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchHistories_Movies_MovieId",
                table: "WatchHistories",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchHistories_Movies_MovieId",
                table: "WatchHistories");

            migrationBuilder.DropIndex(
                name: "IX_WatchHistories_MovieId",
                table: "WatchHistories");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "WatchHistories");
        }
    }
}
