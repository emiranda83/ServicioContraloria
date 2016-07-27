
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Gestor de Estado. 
*****************************************************************************/
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo;

namespace  SENASA.ContraloriaServicios.Integracion.Integracion.Catalogo
{
    public class GestorEstado: IDisposable
    {
        public GestorEstado()
        { }

        public void Dispose()
        { }


		//Inserta Estado
        public String InsertarEstado(string vc_nombreEstado)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.InsertarEstado( vc_nombreEstado);
        }
		//Modifica Estado
        public String ModificarEstado(int i_PK_idEstado,string vc_nombreEstado,int i_activoEstado)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.ModificarEstado( i_PK_idEstado, vc_nombreEstado, i_activoEstado);
        }
		//Consultar Estado
        public DataRow ConsultarEstado(int i_PK_idEstado)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.ConsultarEstado( i_PK_idEstado);
        }
		//Listar Estado
        public DataTable ListarEstado(string filtro)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.ListarEstado(filtro);
        }
   }
}
