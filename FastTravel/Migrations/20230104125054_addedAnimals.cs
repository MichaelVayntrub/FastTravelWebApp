using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTravel.Migrations
{
    /// <inheritdoc />
    public partial class addedAnimals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    animalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    animalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxWeight = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.animalID);
                });
            migrationBuilder.Sql(
            @"
                IF NOT EXISTS (SELECT * FROM dbo.Animals)
                BEGIN
                    INSERT INTO DBO.Animals (animalType,maxWeight,price)
                    VALUES ('Dog',30,59.99),
                           ('Cat',25,45.90),
                           ('Rabbit',20,42.30);
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
