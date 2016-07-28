
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
using Contraloria.Clases.LogicaNegocio;

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
            Estado elEstado = new Estado();
            elEstado.Nombre = vc_nombreEstado;
            using (ServicioEstado elServicioEstado = new ServicioEstado())
            return elServicioEstado.InsertarEstado(elEstado);

        }
		//Modifica Estado
        public String ModificarEstado(int i_PK_idEstado,string vc_nombreEstado,int i_activoEstado)
        {
            Estado elEstado = new Estado();
            elEstado.Id = i_PK_idEstado;
            elEstado.Nombre = vc_nombreEstado;
            elEstado.Activo = i_activoEstado;
            using (ServicioEstado elServicioEstado = new ServicioEstado())
            return elServicioEstado.ModificarEstado(elEstado);
        }
		//Consultar Estado
        public Estado ConsultarEstado(int i_PK_idEstado)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.ConsultarEstado( i_PK_idEstado);
        }
		//Listar Estado
        public List<Estado> ListarEstado(string filtro)
        {
            using (ServicioEstado elServicioEstado = new ServicioEstado())
                return elServicioEstado.ListarEstado(filtro);
        }
   }
}
