using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Facultad.Infraestructure.Migrations
{
    public partial class FacultadV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Facultad",
                columns: new[] { "Id", "CreadoEn", "CreadoPor", "CreadoDesde", "Encargado", "Eliminado", "ModificadoEn", "ModificadoPor", "ModificadoDesde", "Nombre" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dante", "migration", null, false, null, null, null, "FACULTAD DE INGENIERIA DE SISTEMAS E INGENIERIA CIVIL" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dante", "migration", null, false, null, null, null, "FACULTAD DE CIENCIAS DE LA SALUD" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dante", "migration", null, false, null, null, null, "FACULTAD DE CIENCIAS AGROPECUARIAS" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dante", "migration", null, false, null, null, null, "FACULTAD DE CIENCIAS FORESTAS Y AMBIENTALES" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dante", "migration", null, false, null, null, null, "FACULTAD DE MEDICINA HUMANA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Facultad",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
