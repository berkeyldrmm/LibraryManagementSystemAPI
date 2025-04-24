using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibraryProject.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovingBigImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SmallImageBase64",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BigImageBase64",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SmallImageBase64",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigImageBase64",
                table: "Books",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "Books");
        }
    }
}
