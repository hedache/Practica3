using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Colegio.Web.Migrations
{
    public partial class lol4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direecion",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Grado",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Alumnos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Direecion",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Grado",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Alumnos");
        }
    }
}
