using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proiectChioranAndrei.Migrations
{
    public partial class Tara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObiectivTuristic_Oras_OrasID",
                table: "ObiectivTuristic");

            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Oras",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrasID",
                table: "ObiectivTuristic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTara = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oras_TaraID",
                table: "Oras",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_ObiectivTuristic_Oras_OrasID",
                table: "ObiectivTuristic",
                column: "OrasID",
                principalTable: "Oras",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Oras_Tara_TaraID",
                table: "Oras",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObiectivTuristic_Oras_OrasID",
                table: "ObiectivTuristic");

            migrationBuilder.DropForeignKey(
                name: "FK_Oras_Tara_TaraID",
                table: "Oras");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Oras_TaraID",
                table: "Oras");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Oras");

            migrationBuilder.AlterColumn<int>(
                name: "OrasID",
                table: "ObiectivTuristic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ObiectivTuristic_Oras_OrasID",
                table: "ObiectivTuristic",
                column: "OrasID",
                principalTable: "Oras",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
