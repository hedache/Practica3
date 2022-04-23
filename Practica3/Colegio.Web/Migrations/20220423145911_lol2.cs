using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Web.Migrations
{
    public partial class lol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barrios_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BarrioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alumnos_Barrios_BarrioId",
                        column: x => x.BarrioId,
                        principalTable: "Barrios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_BarrioId",
                table: "Alumnos",
                column: "BarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Name",
                table: "Alumnos",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_MunicipioId",
                table: "Barrios",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Barrios_Name",
                table: "Barrios",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Barrios");
        }
    }
}
