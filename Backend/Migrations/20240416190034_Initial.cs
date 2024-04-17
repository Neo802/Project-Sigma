using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectRunAway.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cars_available = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationsId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedAttemptCount = table.Column<int>(type: "int", nullable: false),
                    PersonalQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Doors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price_car = table.Column<float>(type: "real", nullable: true),
                    Tank_capacity = table.Column<float>(type: "real", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarsId);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "UsersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    CarsId = table.Column<int>(type: "int", nullable: false),
                    LocationsId = table.Column<int>(type: "int", nullable: false),
                    Busy_car = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_start = table.Column<DateOnly>(type: "date", nullable: true),
                    Date_end = table.Column<DateOnly>(type: "date", nullable: true),
                    From_hour = table.Column<TimeSpan>(type: "time", nullable: true),
                    To_hour = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => new { x.CarsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_Availability_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "CarsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Availability_Locations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "Locations",
                        principalColumn: "LocationsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headted_seats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ventilated_seats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Steering_wheel_heating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material_of_the_seats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Navigation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorsePower = table.Column<float>(type: "real", nullable: true),
                    Cilindrical_capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadLights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type_seats = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Virtual_cockpit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunroof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeaturesId);
                    table.ForeignKey(
                        name: "FK_Features_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "CarsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Liability",
                columns: table => new
                {
                    LiabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price_liability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liability", x => x.LiabilityId);
                    table.ForeignKey(
                        name: "FK_Liability_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "CarsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Availability_LocationsId",
                table: "Availability",
                column: "LocationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UsersId",
                table: "Cars",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarsId",
                table: "Features",
                column: "CarsId");

            migrationBuilder.CreateIndex(
                name: "IX_Liability_CarsId",
                table: "Liability",
                column: "CarsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Liability");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
