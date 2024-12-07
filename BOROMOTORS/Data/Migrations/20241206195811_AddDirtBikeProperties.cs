using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOROMOTORS.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDirtBikeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Horsepower",
                table: "DirtBikes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TopSpeed",
                table: "DirtBikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "DirtBikes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "DirtBikes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Horsepower",
                table: "DirtBikes");

            migrationBuilder.DropColumn(
                name: "TopSpeed",
                table: "DirtBikes");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "DirtBikes");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "DirtBikes");
        }
    }
}
