using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostOfficeManagematAPI.Migrations
{
    /// <inheritdoc />
    public partial class _0606241migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finalized",
                table: "Shipments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalized",
                table: "Shipments");
        }
    }
}
