using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibraryProject.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updatedescriptionfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Books",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPages",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "Details");
        }
    }
}
