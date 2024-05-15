using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRunAway.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Busy_car",
                table: "Availability",
                newName: "BusyCar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusyCar",
                table: "Availability",
                newName: "Busy_car");
        }
    }
}
