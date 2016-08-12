
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       11/08/2016
** Componente:  
** Descripcion: Servicio de MedioNotificacion. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Componentes.Sistemas.Clases;
//using System.Linq;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.
{
    public class ServicioMedioNotificacion : Servicio, IDisposable
    {
        
        public ServicioMedioNotificacion()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  MedioNotificacion
        public String InsertarMedioNotificacion(string vc_NombreMedio,int i_activoMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_insertar";

            
			miComando.Parameters.Add("@vc_NombreMedio", SqlDbType.VarChar).Value = vc_NombreMedio;
            
			miComando.Parameters.Add("@i_activoMedio", SqlDbType.Int).Value = i_activoMedio;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  MedioNotificacion
        public String ModificarMedioNotificacion(int i_PK_idMedio,string vc_NombreMedio,int i_activoMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_modificar";

            
			miComando.Parameters.Add("@i_PK_idMedio", SqlDbType.Int).Value = i_PK_idMedio;
            
			miComando.Parameters.Add("@vc_NombreMedio", SqlDbType.VarChar).Value = vc_NombreMedio;
            
			miComando.Parameters.Add("@i_activoMedio", SqlDbType.Int).Value = i_activoMedio;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  MedioNotificacion
        public DataRow ConsultarMedioNotificacion(int i_PK_idMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_Consultar";

            
			miComando.Parameters.Add("@i_PK_idMedio", SqlDbType.Int).Value = i_PK_idMedio;

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                return miDataSet.Tables[0].Rows[0];
            }
            catch
            {
                return null;
            }

        }
		//Listar  MedioNotificacion
        public DataTable ListarMedioNotificacion(string filtro)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_Listar";

            miComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
            
            

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                return miDataSet.Tables[0];
            }
            catch
            {
                return null;
            }

        }
    }
}
