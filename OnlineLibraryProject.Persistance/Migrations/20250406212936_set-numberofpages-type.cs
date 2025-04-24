using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibraryProject.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class setnumberofpagestype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NumberOfPages",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
