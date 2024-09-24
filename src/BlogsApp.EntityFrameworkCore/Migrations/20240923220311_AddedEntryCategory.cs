using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogsApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntryCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppEntries_CategoryId",
                table: "AppEntries",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEntries_Categories_CategoryId",
                table: "AppEntries",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEntries_Categories_CategoryId",
                table: "AppEntries");

            migrationBuilder.DropIndex(
                name: "IX_AppEntries_CategoryId",
                table: "AppEntries");
        }
    }
}
