using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRunAway.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cars_available",
                table: "Locations",
                newName: "CarsAvailable");

            migrationBuilder.RenameColumn(
                name: "Price_liability",
                table: "Liability",
                newName: "PriceLiability");

            migrationBuilder.RenameColumn(
                name: "Sunroof",
                table: "Features",
                newName: "SunRoof");

            migrationBuilder.RenameColumn(
                name: "Virtual_cockpit",
                table: "Features",
                newName: "VirtualCockpit");

            migrationBuilder.RenameColumn(
                name: "Ventilated_seats",
                table: "Features",
                newName: "VentilatedSeats");

            migrationBuilder.RenameColumn(
                name: "Type_seats",
                table: "Features",
                newName: "TypeSeats");

            migrationBuilder.RenameColumn(
                name: "Steering_wheel_heating",
                table: "Features",
                newName: "SteeringWheelHeating");

            migrationBuilder.RenameColumn(
                name: "Material_of_the_seats",
                table: "Features",
                newName: "MaterialOfTheSeats");

            migrationBuilder.RenameColumn(
                name: "Headted_seats",
                table: "Features",
                newName: "HeadtedSeats");

            migrationBuilder.RenameColumn(
                name: "Cilindrical_capacity",
                table: "Features",
                newName: "CilindricalCapacity");

            migrationBuilder.RenameColumn(
                name: "Tank_capacity",
                table: "Cars",
                newName: "TankCapacity");

            migrationBuilder.RenameColumn(
                name: "Price_car",
                table: "Cars",
                newName: "PriceCar");

            migrationBuilder.RenameColumn(
                name: "To_hour",
                table: "Availability",
                newName: "ToHour");

            migrationBuilder.RenameColumn(
                name: "From_hour",
                table: "Availability",
                newName: "FromHour");

            migrationBuilder.RenameColumn(
                name: "Date_start",
                table: "Availability",
                newName: "DateStart");

            migrationBuilder.RenameColumn(
                name: "Date_end",
                table: "Availability",
                newName: "DateEnd");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CarsAvailable",
                table: "Locations",
                newName: "Cars_available");

            migrationBuilder.RenameColumn(
                name: "PriceLiability",
                table: "Liability",
                newName: "Price_liability");

            migrationBuilder.RenameColumn(
                name: "SunRoof",
                table: "Features",
                newName: "Sunroof");

            migrationBuilder.RenameColumn(
                name: "VirtualCockpit",
                table: "Features",
                newName: "Virtual_cockpit");

            migrationBuilder.RenameColumn(
                name: "VentilatedSeats",
                table: "Features",
                newName: "Ventilated_seats");

            migrationBuilder.RenameColumn(
                name: "TypeSeats",
                table: "Features",
                newName: "Type_seats");

            migrationBuilder.RenameColumn(
                name: "SteeringWheelHeating",
                table: "Features",
                newName: "Steering_wheel_heating");

            migrationBuilder.RenameColumn(
                name: "MaterialOfTheSeats",
                table: "Features",
                newName: "Material_of_the_seats");

            migrationBuilder.RenameColumn(
                name: "HeadtedSeats",
                table: "Features",
                newName: "Headted_seats");

            migrationBuilder.RenameColumn(
                name: "CilindricalCapacity",
                table: "Features",
                newName: "Cilindrical_capacity");

            migrationBuilder.RenameColumn(
                name: "TankCapacity",
                table: "Cars",
                newName: "Tank_capacity");

            migrationBuilder.RenameColumn(
                name: "PriceCar",
                table: "Cars",
                newName: "Price_car");

            migrationBuilder.RenameColumn(
                name: "ToHour",
                table: "Availability",
                newName: "To_hour");

            migrationBuilder.RenameColumn(
                name: "FromHour",
                table: "Availability",
                newName: "From_hour");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Availability",
                newName: "Date_start");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "Availability",
                newName: "Date_end");
        }
    }
}
