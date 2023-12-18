using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Facultad.Infraestructure.Migrations
{
    public partial class FacultadV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreadoDesde",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "CreadoEn",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "CreadoPor",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "ModificadoDesde",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "ModificadoEn",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.DropColumn(
                name: "ModificadoPor",
                schema: "dbo",
                table: "Escuela");

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPor",
                schema: "dbo",
                table: "Facultad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreadoPor",
                schema: "dbo",
                table: "Facultad",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ModificadoPor",
                schema: "dbo",
                table: "Facultad",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreadoPor",
                schema: "dbo",
                table: "Facultad",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreadoDesde",
                schema: "dbo",
                table: "Escuela",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreadoEn",
                schema: "dbo",
                table: "Escuela",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreadoPor",
                schema: "dbo",
                table: "Escuela",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "dbo",
                table: "Escuela",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoDesde",
                schema: "dbo",
                table: "Escuela",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificadoEn",
                schema: "dbo",
                table: "Escuela",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ModificadoPor",
                schema: "dbo",
                table: "Escuela",
                type: "bigint",
                nullable: true);
        }
    }
}
