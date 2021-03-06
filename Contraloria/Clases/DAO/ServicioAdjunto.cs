
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
using Contraloria.Clases.LogicaNegocio;

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
        public String InsertarAdjunto(Adjunto elAdjunto)
        {
            miComando.CommandText = "SPR_Sol_Adjunto_insertar";

            
			miComando.Parameters.Add("@img_archivoAdjunto", SqlDbType.VarBinary).Value = elAdjunto.Imagen;
            
            miComando.Parameters.Add("@vc_descripcionAdjunto", SqlDbType.VarChar).Value = elAdjunto.Descripcion;
            
			miComando.Parameters.Add("@vc_tipoAdjunto", SqlDbType.VarChar).Value = elAdjunto.Tipo;

            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
    }
}
