using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLIGATORIO1_P3.ACCESODATOS.Migrations
{
    /// <inheritdoc />
    public partial class datosPruebaCabania : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Cabania values('bahia vik','hote de lujo en jose ignacio','true','true',3,'bahia_vik.jpg',1,3)");
            migrationBuilder.Sql("insert into Cabania values('La balsa','chalet en jose ignacio','false','true',3,'La_balsa.jpg',1,9)");
            migrationBuilder.Sql("insert into Cabania values('costa esmeralda','cabania en la playa','false','true',2,'costa_esmeralda.jpg',1,1)");
            migrationBuilder.Sql("insert into Cabania values('el legado','hotel de lujo','true','true',4,'el_legado.jpg',1,5)");
            migrationBuilder.Sql("insert into Cabania values('en calma','casa en la playa','false','false',2,'en_calma.jpg',1,8)");
            migrationBuilder.Sql("insert into Cabania values('Laguna garzon lodge','bungalow sobre el agua','false','true',3,'Laguna_garzon_lodge.jpg',1,4)");
            migrationBuilder.Sql("insert into Cabania values('manuel lobo','cuarto privado en el centro','false','true',2,'manuel_lobo.jpg',1,3)");
            migrationBuilder.Sql("insert into Cabania values('Pinos de la quebrada','hote de lujo para turistas','true','true',4,'Pinos_de_la_quebrada.jpg',1,5)");
            migrationBuilder.Sql("insert into Cabania values('tacuabe','chalet para 2 personas','false','true',2,'tacuabe.jpg',1,9)");
            migrationBuilder.Sql("insert into Cabania values('casa de playa','casa en la playa','true','true',4,'casa_de_playa.jpg',1,5)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
