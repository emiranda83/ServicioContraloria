
/****************************************************************************
**
** Compania:    SENASA - MAG
** Sistema:     Sistema Contraloria de Servicios
** Autor:       Estephany Miranda
** Fecha:       27/07/2016
** Componente:  
** Descripcion: Servicio de Estado. 
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
    public class ServicioEstado : Servicio, IDisposable
    {
        
        public ServicioEstado()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  Estado
        public String InsertarEstado(string vc_nombreEstado)
        {
            miComando.CommandText = "SPR_Cat_Estado_insertar";

            
			miComando.Parameters.Add("@vc_nombreEstado", SqlDbType.VarChar).Value = vc_nombreEstado;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  Estado
        public String ModificarEstado(int i_PK_idEstado,string vc_nombreEstado,int i_activoEstado)
        {
            miComando.CommandText = "SPR_Cat_Estado_modificar";

            
			miComando.Parameters.Add("@i_PK_idEstado", SqlDbType.Int).Value = i_PK_idEstado;
            
			miComando.Parameters.Add("@vc_nombreEstado", SqlDbType.VarChar).Value = vc_nombreEstado;
            
			miComando.Parameters.Add("@i_activoEstado", SqlDbType.Int).Value = i_activoEstado;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  Estado
        public DataRow ConsultarEstado(int i_PK_idEstado)
        {
            miComando.CommandText = "SPR_Cat_Estado_Consultar";

            
			miComando.Parameters.Add("@i_PK_idEstado", SqlDbType.Int).Value = i_PK_idEstado;

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
		//Listar  Estado
        public DataTable ListarEstado(string filtro)
        {
            miComando.CommandText = "SPR_Cat_Estado_Listar";

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
