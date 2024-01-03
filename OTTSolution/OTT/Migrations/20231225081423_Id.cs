using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OTT.Migrations
{
    public partial class Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchHistories",
                table: "WatchHistories");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "WatchHistories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "WatchHistoryId",
                table: "WatchHistories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchHistories",
                table: "WatchHistories",
                column: "WatchHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WatchHistories_Email",
                table: "WatchHistories",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchHistories",
                table: "WatchHistories");

            migrationBuilder.DropIndex(
                name: "IX_WatchHistories_Email",
                table: "WatchHistories");

            migrationBuilder.DropColumn(
                name: "WatchHistoryId",
                table: "WatchHistories");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "WatchHistories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchHistories",
                table: "WatchHistories",
                columns: new[] { "Email", "Details" });
        }
    }
}
