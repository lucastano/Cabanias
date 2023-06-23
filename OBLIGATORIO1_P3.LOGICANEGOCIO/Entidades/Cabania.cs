using Microsoft.EntityFrameworkCore;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Excepciones;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Value_Objects;

namespace OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades
{

    [Table("Cabania")]


    [Index(nameof(Nombre), IsUnique = true, IsDescending = new[] { true }, Name = "UX_CABAÑA_NOMBRE")]
    public class Cabania : IValidable
    {

        #region Propiedades
        [Required(ErrorMessage ="debe ingresar nombre")]

        
        public NombreCabaniaVO Nombre { get; set; }

        [StringLength(500, MinimumLength = 10, ErrorMessage = "debe tener entre 10 y 500 caracteres")]
        public string Descripcion { get; set; }
        public bool? Jacuzzi { get; set; }
        public bool? Habilitada { get; set; }

        [Key]
        
        public int NumeroHabitacion { get; set; }
        public int CantidadMaximaPersonas { get; set; }
        public string? Foto { get; set; }
        // secuenciador en un futuro va a aumnetar a medidad de que se suban fotos 
        public  int secuenciador { get; set; } 
        public Tipo? TipoCabana { get; set; }
        public List<Mantenimiento> Mantenimientos { get; set; } =new List<Mantenimiento>();
        #endregion

        

        #region Validaciones
        public void Validar()
        {
          
           

           //valida el tipo de archivo, que sea extencion png o jpg de no serlo se le avisara 
            if (!validarTipoArchivo()) throw new CabaniaException("solo se permiten archivos .png o .jpg");
        }

       

      
       
       
        

        #endregion

        

       //Validacion para controlar la extencion de la imagen , ya que solo acepta .png y .jpg 
       // despues de validar , le crea un nuevo nombre a la imagen 
       //TODO: verificar si se utiliza para algo GUARDAR NOMBRE DE IMAGEN
        public bool validarTipoArchivo()
        { 
            bool resultado = false;
            var cadena = this.Foto;
           
            if(cadena.Substring(cadena.Length-4,4).ToLower()==".jpg" || cadena.Substring(cadena.Length - 4, 4).ToLower() == ".png")
            {
                resultado = true;
                this.crearNombreImagen(cadena);
            }

            return resultado;
        }
        public void crearNombreImagen(string nombreoriginal) 
        {
            int secuenciador = this.secuenciador;
            
            var nuevoNombre = "";
            for(int i = 0;i<Nombre.Valor.Length;i++)
            {
                if (char.IsSeparator(Nombre.Valor[i]))
                {
                    nuevoNombre += '_';
                }
                else
                {
                    nuevoNombre += Nombre.Valor[i];
                }

            }

            this.Foto = nuevoNombre+"00"+secuenciador +nombreoriginal.Substring(nombreoriginal.Length-4,4);
           
        }

        

    }
}

