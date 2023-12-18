using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Facultad.Infraestructure.Migrations
{
    public partial class FacultadV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Escuela",
                columns: new[] { "Id", "FacultadId", "Nombre" },
                values: new object[,]
                {
                    { 1L, 1L, "ESCUELA DE INGENIERIA CIVIL" },
                    { 2L, 1L, "ESCUELA DE INGENIERIA DE SISTEMAS" },
                    { 3L, 2L, "ESCUELA DE ENFERMERIA" },
                    { 4L, 2L, "ESCUELA DE PSICOLOGIA" },
                    { 5L, 3L, "ESCUELA DE AGRONOMIA" },
                    { 6L, 3L, "ESCUELA DE INGENIERIA AGROINDUSTRIAL" },
                    { 7L, 4L, "ESCUELA DE INGENIERIA FORESTAL" },
                    { 8L, 4L, "ESCUELA DE INGENIERIA AMBIENTAL" },
                    { 9L, 5L, "ESCUELA DE MEDICINA HUMANA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Escuela",
                keyColumn: "Id",
                keyValue: 9L);
        }
    }
}
