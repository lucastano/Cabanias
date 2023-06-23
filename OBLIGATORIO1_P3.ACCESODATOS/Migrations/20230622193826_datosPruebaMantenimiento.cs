using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBLIGATORIO1_P3.ACCESODATOS.Migrations
{
    /// <inheritdoc />
    public partial class datosPruebaMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-10 00:00:00.0000000','reparacion en cocina',1000,'claudio',1)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-10 00:00:00.0000000','reparacion de enchufes',599,'claudio',1)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-7 00:00:00.0000000','se cambio un vidrio',1000,'andres',1)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-9 00:00:00.0000000','limpieza total',1000,'claudio',2)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-8 00:00:00.0000000','cambio de sillon',600,'claudio',2)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-7 00:00:00.0000000','se reparo griferia',1000,'jonathan',3)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-10 00:00:00.0000000','reparacion de cerradura',1000,'claudio',4)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-10 00:00:00.0000000','limpieza total ',700,'claudio',4)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-10 00:00:00.0000000','limpieza de grasera',1000,'German',4)");
            migrationBuilder.Sql("insert into Mantenimiento values('2023-05-11 00:00:00.0000000','reparacion caño del baño',11000,'claudio',4)");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
