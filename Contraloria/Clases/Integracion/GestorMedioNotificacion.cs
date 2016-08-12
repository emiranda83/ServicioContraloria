
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Gestor de MedioNotificacion. 
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
    public class GestorMedioNotificacion: IDisposable
    {
        public GestorMedioNotificacion()
        { }

        public void Dispose()
        { }


		//Inserta MedioNotificacion
        public String InsertarMedioNotificacion(string vc_NombreMedio,int i_activoMedio)
        {
            using (ServicioMedioNotificacion elServicioMedioNotificacion = new ServicioMedioNotificacion())
                return elServicioMedioNotificacion.InsertarMedioNotificacion( vc_NombreMedio, i_activoMedio);
        }
		//Modifica MedioNotificacion
        public String ModificarMedioNotificacion(int i_PK_idMedio,string vc_NombreMedio,int i_activoMedio)
        {
            using (ServicioMedioNotificacion elServicioMedioNotificacion = new ServicioMedioNotificacion())
                return elServicioMedioNotificacion.ModificarMedioNotificacion( i_PK_idMedio, vc_NombreMedio, i_activoMedio);
        }
		//Consultar MedioNotificacion
        public DataRow ConsultarMedioNotificacion(int i_PK_idMedio)
        {
            using (ServicioMedioNotificacion elServicioMedioNotificacion = new ServicioMedioNotificacion())
                return elServicioMedioNotificacion.ConsultarMedioNotificacion( i_PK_idMedio);
        }
		//Listar MedioNotificacion
        public DataTable ListarMedioNotificacion(string filtro)
        {
            using (ServicioMedioNotificacion elServicioMedioNotificacion = new ServicioMedioNotificacion())
                return elServicioMedioNotificacion.ListarMedioNotificacion(filtro);
        }
   }
}
