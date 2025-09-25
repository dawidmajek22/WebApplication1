using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class klasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nr_grupy",
                table: "Hod_Rasy",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "klasa_lookup",
                columns: table => new
                {
                    KLASA_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAZWA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OD_ILE_MIESIECY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DO_ILE_MIESIECY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TYP_OCENY = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_klasa_lookup", x => x.KLASA_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "klasa_lookup");

            migrationBuilder.AlterColumn<int>(
                name: "nr_grupy",
                table: "Hod_Rasy",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
