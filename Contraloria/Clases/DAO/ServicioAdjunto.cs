
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       07/09/2016
** Componente:  
** Descripcion: Servicio de Adjunto. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Componentes.Sistemas.Clases;
//using System.Linq;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Solicitud
{
    public class ServicioAdjunto : Servicio, IDisposable
    {
        
        public ServicioAdjunto()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Adjunto
        public String InsertarAdjunto(string img_archivoAdjunto,string vc_descripcionAdjunto,string vc_tipoAdjunto)
        {
            miComando.CommandText = "SPR_Sol_Adjunto_insertar";

            
			miComando.Parameters.Add("@img_archivoAdjunto", SqlDbType.VarChar).Value = img_archivoAdjunto;
            
			miComando.Parameters.Add("@vc_descripcionAdjunto", SqlDbType.VarChar).Value = vc_descripcionAdjunto;
            
			miComando.Parameters.Add("@vc_tipoAdjunto", SqlDbType.VarChar).Value = vc_tipoAdjunto;
                      

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
    }
}
