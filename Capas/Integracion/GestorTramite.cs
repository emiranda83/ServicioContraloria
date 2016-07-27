
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
using  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo;

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
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.InsertarTramite( vc_NombreTramite);
        }
		//Modifica Tramite
        public String ModificarTramite(int i_PK_idTramite,string vc_NombreTramite,int i_activoTramite)
        {
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ModificarTramite( i_PK_idTramite, vc_NombreTramite, i_activoTramite);
        }
		//Consultar Tramite
        public DataRow ConsultarTramite(int i_PK_idTramite)
        {
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ConsultarTramite( i_PK_idTramite);
        }
		//Listar Tramite
        public DataTable ListarTramite(string filtro)
        {
            using (ServicioTramite elServicioTramite = new ServicioTramite())
                return elServicioTramite.ListarTramite(filtro);
        }
   }
}
