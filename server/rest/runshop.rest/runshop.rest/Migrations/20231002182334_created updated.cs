using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace runShop.services.Migrations
{
    /// <inheritdoc />
    public partial class createdupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update",
                table: "users",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "Create",
                table: "users",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "users",
                newName: "Update");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "Create");
        }
    }
}
