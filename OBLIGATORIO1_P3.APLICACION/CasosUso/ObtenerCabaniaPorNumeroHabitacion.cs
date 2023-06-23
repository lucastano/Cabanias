using OBLIGATORIO1_P3.APLICACION.InterfacesCasoUso;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Entidades;
using OBLIGATORIO1_P3.LOGICANEGOCIO.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBLIGATORIO1_P3.APLICACION.CasosUso
{
    public class ObtenerCabaniaPorNumeroHabitacion:IObtenerCabaniaPorNumeroHabitacion
    {
        ICabaniaRepositorio repositorio;
        public ObtenerCabaniaPorNumeroHabitacion( ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Cabania? Ejecutar(int numeroHabitacion)
        {
            if (numeroHabitacion == 0) throw new Exception("numero de habitacion no existe");
            return this.repositorio.Obtener(numeroHabitacion);
        }
    }
}
