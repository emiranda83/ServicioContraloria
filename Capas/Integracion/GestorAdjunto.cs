
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       07/09/2016
** Componente:  
** Descripcion: Gestor de Adjunto. 
*****************************************************************************/
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using  SENASA.ContraloriaServicios.Logica.Servicios.Solicitud;

namespace  SENASA.ContraloriaServicios.Integracion.Integracion.Solicitud
{
    public class GestorAdjunto: IDisposable
    {
        public GestorAdjunto()
        { }

        public void Dispose()
        { }


		//Inserta Adjunto
        public String InsertarAdjunto(string img_archivoAdjunto,string vc_descripcionAdjunto,string vc_tipoAdjunto)
        {
            using (ServicioAdjunto elServicioAdjunto = new ServicioAdjunto())
                return elServicioAdjunto.InsertarAdjunto( img_archivoAdjunto, vc_descripcionAdjunto, vc_tipoAdjunto);
        }
   }
}
