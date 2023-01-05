using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastTravel.Migrations
{
    /// <inheritdoc />
    public partial class addedPetTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetTickets",
                columns: table => new
                {
                    petTicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    animalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetTickets", x => x.petTicketID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetTickets");
        }
    }
}
