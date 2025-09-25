using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Adresy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
            //    name: "Opis",
            //    table: "Hodowla",
            //    newName: "Masc");

            //migrationBuilder.AddColumn<int>(
            //    name: "IdHodowcy",
            //    table: "Hodowla",
            //    type: "int",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypAdresu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Panstwo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miejscowosc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Www = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelStacjonarny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelKomorkowy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HodowlaAdres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HodowlaId = table.Column<int>(type: "int", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HodowlaAdres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HodowlaAdres_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HodowlaAdres_Hodowla_HodowlaId",
                        column: x => x.HodowlaId,
                        principalTable: "Hodowla",
                        principalColumn: "HodowlaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hodowla_IdHodowcy",
                table: "Hodowla",
                column: "IdHodowcy");

            migrationBuilder.CreateIndex(
                name: "IX_HodowlaAdres_AdresId",
                table: "HodowlaAdres",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_HodowlaAdres_HodowlaId",
                table: "HodowlaAdres",
                column: "HodowlaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hodowla_Hodowca_IdHodowcy",
                table: "Hodowla",
                column: "IdHodowcy",
                principalTable: "Hodowca",
                principalColumn: "IdHodowcy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hodowla_Hodowca_IdHodowcy",
                table: "Hodowla");

            migrationBuilder.DropTable(
                name: "HodowlaAdres");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropIndex(
                name: "IX_Hodowla_IdHodowcy",
                table: "Hodowla");

            migrationBuilder.DropColumn(
                name: "IdHodowcy",
                table: "Hodowla");

            migrationBuilder.RenameColumn(
                name: "Masc",
                table: "Hodowla",
                newName: "Opis");
        }
    }
}
