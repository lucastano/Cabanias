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
    public class ObtenerListaCabaniasHabilitadas:IObtenerListaCabaniasHabilitadas
    {
        ICabaniaRepositorio repositorio;

        public ObtenerListaCabaniasHabilitadas(ICabaniaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public List<Cabania> Ejecutar()
        {
            return this.repositorio.CabaniasHabilitadas();
        }
    }
}
