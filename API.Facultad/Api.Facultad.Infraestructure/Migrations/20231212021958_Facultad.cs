using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Facultad.Infraestructure.Migrations
{
    public partial class Facultad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Facultad",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Encargado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreadoPor = table.Column<long>(type: "bigint", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoDesde = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModificadoPor = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoDesde = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escuela",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultadId = table.Column<long>(type: "bigint", nullable: false),
                    CreadoPor = table.Column<long>(type: "bigint", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoDesde = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModificadoPor = table.Column<long>(type: "bigint", nullable: true),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModificadoDesde = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escuela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escuela_Facultad_FacultadId",
                        column: x => x.FacultadId,
                        principalSchema: "dbo",
                        principalTable: "Facultad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escuela_FacultadId",
                schema: "dbo",
                table: "Escuela",
                column: "FacultadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escuela",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Facultad",
                schema: "dbo");
        }
    }
}
