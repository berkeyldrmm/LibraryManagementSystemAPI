using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibraryProject.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class setbookratingsrelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRatiings",
                table: "BookRatiings");

            migrationBuilder.RenameTable(
                name: "BookRatiings",
                newName: "BookRatings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRatings",
                table: "BookRatings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookId",
                table: "BookRatings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_UserId",
                table: "BookRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRatings_Books_BookId",
                table: "BookRatings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRatings_Users_UserId",
                table: "BookRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRatings_Books_BookId",
                table: "BookRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRatings_Users_UserId",
                table: "BookRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRatings",
                table: "BookRatings");

            migrationBuilder.DropIndex(
                name: "IX_BookRatings_BookId",
                table: "BookRatings");

            migrationBuilder.DropIndex(
                name: "IX_BookRatings_UserId",
                table: "BookRatings");

            migrationBuilder.RenameTable(
                name: "BookRatings",
                newName: "BookRatiings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRatiings",
                table: "BookRatiings",
                column: "Id");
        }
    }
}
