using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTravel.Migrations
{
    /// <inheritdoc />
    public partial class addedLuggage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Luggages",
                columns: table => new
                {
                    luggageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    luggageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxWeight = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luggages", x => x.luggageID);
                });
            migrationBuilder.Sql(@"
                IF NOT EXISTS(SELECT * FROM DBO.Luggages)
                BEGIN
                    INSERT INTO DBO.Luggages(luggageType,maxWeight,price)
                    VALUES('Small', 10, 25.50),
                           ('Medium', 20, 58.90),
                           ('Big', 30, 82.20),
                           ('Humongous', 40, 125.50);
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Luggages");
        }
    }
}
