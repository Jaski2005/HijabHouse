using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HijabHouse.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUr1",
                table: "Dresses",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Dresses",
                newName: "ImageUr1");
        }
    }
}
