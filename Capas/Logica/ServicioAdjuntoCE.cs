
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       07/09/2016
** Componente:  
** Descripcion: ServicioCE de Adjunto. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using Componentes_MOBILE.Clases;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Solicitud
{
    public class ServicioAdjuntoCE:AccesoBDCE
    {
        
        public ServicioAdjuntoCE()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Adjunto
        public String InsertarAdjunto(string img_archivoAdjunto,string vc_descripcionAdjunto,string vc_tipoAdjunto)
        {
            consulta = @"insert into Sol_Adjunto(img_archivoAdjunto,vc_descripcionAdjunto,vc_tipoAdjunto)
            values ('"+img_archivoAdjunto+"','"+vc_descripcionAdjunto+"','"+vc_tipoAdjunto+"')";

             return Procesamiento(consulta);
        }
    }
}
