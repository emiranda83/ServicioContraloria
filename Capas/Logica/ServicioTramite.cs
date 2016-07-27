
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       15/07/2016
** Componente:  
** Descripcion: Servicio de Tramite. 
*****************************************************************************/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Componentes.Sistemas.Clases;
//using System.Linq;
using System.Text;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo
{
    public class ServicioTramite : Servicio, IDisposable
    {
        
        public ServicioTramite()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Tramite
        public String InsertarTramite(string vc_NombreTramite)
        {
            miComando.CommandText = "SPR_Cat_Tramite_insertar";

            
			miComando.Parameters.Add("@vc_NombreTramite", SqlDbType.VarChar).Value = vc_NombreTramite;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  Tramite
        public String ModificarTramite(int i_PK_idTramite,string vc_NombreTramite,int i_activoTramite)
        {
            miComando.CommandText = "SPR_Cat_Tramite_modificar";

            
			miComando.Parameters.Add("@i_PK_idTramite", SqlDbType.Int).Value = i_PK_idTramite;
            
			miComando.Parameters.Add("@vc_NombreTramite", SqlDbType.VarChar).Value = vc_NombreTramite;
            
			miComando.Parameters.Add("@i_activoTramite", SqlDbType.Int).Value = i_activoTramite;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  Tramite
        public DataRow ConsultarTramite(int i_PK_idTramite)
        {
            miComando.CommandText = "SPR_Cat_Tramite_Consultar";

            
			miComando.Parameters.Add("@i_PK_idTramite", SqlDbType.Int).Value = i_PK_idTramite;

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
		//Listar  Tramite
        public DataTable ListarTramite(string filtro)
        {
            miComando.CommandText = "SPR_Cat_Tramite_Listar";

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
