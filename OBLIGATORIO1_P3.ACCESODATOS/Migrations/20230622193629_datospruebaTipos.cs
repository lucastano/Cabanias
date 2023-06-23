using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLIGATORIO1_P3.ACCESODATOS.Migrations
{
    /// <inheritdoc />
    public partial class datospruebaTipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Tipo values('De playa','cabaña cerca de la playa',250)");
            migrationBuilder.Sql("insert into Tipo values('De Campo','cabaña en el campo',150)");
            migrationBuilder.Sql("insert into Tipo values('Lujo','cabaña de lujo',500)");
            migrationBuilder.Sql("insert into Tipo values('Delux','cabaña semi lujo',400)");
            migrationBuilder.Sql("insert into Tipo values('Privada','cabaña privada en el lago',1500)");
            migrationBuilder.Sql("insert into Tipo values('standart','cabaña nivel standart',50)");
            migrationBuilder.Sql("insert into Tipo values('turista','cabaña nivel turista',50)");
            migrationBuilder.Sql("insert into Tipo values('casa','hogar compartido',20)");
            migrationBuilder.Sql("insert into Tipo values('chalet','chalet en la costa',50)");
            migrationBuilder.Sql("insert into Tipo values('bungalow','bungalow basico',50)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
