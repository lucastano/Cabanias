using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLIGATORIO1_P3.ACCESODATOS.Migrations
{
    /// <inheritdoc />
    public partial class nuevabd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CostoPorHuesped = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cabania",
                columns: table => new
                {
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Jacuzzi = table.Column<bool>(type: "bit", nullable: true),
                    Habilitada = table.Column<bool>(type: "bit", nullable: true),
                    CantidadMaximaPersonas = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    secuenciador = table.Column<int>(type: "int", nullable: false),
                    TipoCabanaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabania", x => x.NumeroHabitacion);
                    table.ForeignKey(
                        name: "FK_Cabania_Tipo_TipoCabanaId",
                        column: x => x.TipoCabanaId,
                        principalTable: "Tipo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaMantenimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoMantenimiento = table.Column<double>(type: "float", nullable: false),
                    Trabajador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cabaniaCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Cabania_cabaniaCodigo",
                        column: x => x.cabaniaCodigo,
                        principalTable: "Cabania",
                        principalColumn: "NumeroHabitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabania_TipoCabanaId",
                table: "Cabania",
                column: "TipoCabanaId");

            migrationBuilder.CreateIndex(
                name: "UX_CABAÑA_NOMBRE",
                table: "Cabania",
                column: "Nombre",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_cabaniaCodigo",
                table: "Mantenimiento",
                column: "cabaniaCodigo");

            migrationBuilder.CreateIndex(
                name: "UX_TIPO_NOMBRE",
                table: "Tipo",
                column: "Nombre",
                unique: true,
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "MailIndex",
                table: "Usuarios",
                column: "Mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cabania");

            migrationBuilder.DropTable(
                name: "Tipo");
        }
    }
}
