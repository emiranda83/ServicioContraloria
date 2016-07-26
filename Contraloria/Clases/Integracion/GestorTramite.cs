
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Gestor de Tramite. 
*****************************************************************************/
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using SENASA.ContraloriaServicios.Logica.Servicios.Catalogo;
using Contraloria.Clases.LogicaNegocio;

namespace  SENASA.ContraloriaServicios.Integracion.Integracion.Catalogo
{
    public class GestorTramite: IDisposable
    {
        public GestorTramite()
        { }

        public void Dispose()
        { }


		//Inserta Tramite
        public String InsertarTramite(string vc_NombreTramite)
        {
            Tramite elTramite = new Tramite();
            elTramite.Nombre = vc_NombreTramite;
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.InsertarTramite(elTramite);
        }
		//Modifica Tramite
        public String ModificarTramite(int i_PK_idTramite,string vc_NombreTramite,int i_activoTramite)
        {
            Tramite elTramite = new Tramite();
            elTramite.Id = i_PK_idTramite;
            elTramite.Nombre = vc_NombreTramite;
            elTramite.Estado = i_activoTramite;
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ModificarTramite(elTramite);
        }
		//Consultar Tramite
        public Tramite  ConsultarTramite(int i_PK_idTramite)
        {
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ConsultarTramite( i_PK_idTramite);
        }
		//Listar Tramite
        public List<Tramite> ListarTramite(string filtro)
        {
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ListarTramite(filtro);
        }
   }
}
