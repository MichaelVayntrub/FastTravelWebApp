using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTravel.Migrations
{
    /// <inheritdoc />
    public partial class addedPorts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightsData",
                columns: table => new
                {
                    flightNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source = table.Column<int>(type: "int", nullable: false),
                    dateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    destination = table.Column<int>(type: "int", nullable: false),
                    dateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stop1 = table.Column<int>(type: "int", nullable: true),
                    date1 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    stop2 = table.Column<int>(type: "int", nullable: true),
                    date2 = table.Column<DateTime>(type: "datetime2", nullable: true),
                    plane = table.Column<int>(type: "int", nullable: false),
                    child = table.Column<float>(type: "real", nullable: false),
                    adult = table.Column<float>(type: "real", nullable: false),
                    elder = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsData", x => x.flightNumber);
                });

            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    planeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    seatsNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.planeID);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    portID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.portID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightsData");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
