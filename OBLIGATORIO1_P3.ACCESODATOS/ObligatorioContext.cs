using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;

namespace OBLIGATORIO1_P3.ACCESODATOS
{
    public class ObligatorioContext:DbContext
    {
        public DbSet<Cabania>Cabanias { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public ObligatorioContext(DbContextOptions<ObligatorioContext> options):base(options)
        {
        
        
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    base.OnConfiguring(options);
        //    options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lucas\OneDrive\Escritorio\obligatorio2 p3\bdObligatorio2.mdf;Integrated Security=True;Connect Timeout=30");
        //}




    }
}
