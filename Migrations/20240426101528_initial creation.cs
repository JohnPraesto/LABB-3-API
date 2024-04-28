using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LABB_3_API.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HobbyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.HobbyId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PersonHobbyConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonHobbyConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_PersonHobbyConnections_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonHobbyConnections_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "HobbyId", "Description", "HobbyName", "Links" },
                values: new object[,]
                {
                    { 1, "Pleasant trips out in nature on horseback", "Horseback riding", "[\"https://www.visitvarberg.se/ovrigt/outdoor/outdoorsidor/rida.html\"]" },
                    { 2, "Hitting ball over net with racket", "Tennis", "[\"https://www.tennis.se/\"]" },
                    { 3, "Miniature strategy war game", "Warhammer", "[\"https://www.warhammer.com/\"]" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "PersonName", "Phone" },
                values: new object[,]
                {
                    { 1, "Georgette", "+468712049" },
                    { 2, "Gunnhild", "00000001" },
                    { 3, "Greger", "0704561237" }
                });

            migrationBuilder.InsertData(
                table: "PersonHobbyConnections",
                columns: new[] { "ConnectionId", "HobbyId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 3, 3 },
                    { 6, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbyConnections_HobbyId",
                table: "PersonHobbyConnections",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonHobbyConnections_PersonId",
                table: "PersonHobbyConnections",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonHobbyConnections");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
