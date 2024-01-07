using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiectChioranAndrei.Migrations
{
    public partial class OraseSiObiective : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oras",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeOras = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oras", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ObiectivTuristic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numar = table.Column<int>(type: "int", nullable: false),
                    Telefon = table.Column<int>(type: "int", nullable: false),
                    OrasID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObiectivTuristic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ObiectivTuristic_Oras_OrasID",
                        column: x => x.OrasID,
                        principalTable: "Oras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObiectivTuristic_OrasID",
                table: "ObiectivTuristic",
                column: "OrasID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObiectivTuristic");

            migrationBuilder.DropTable(
                name: "Oras");
        }
    }
}
