
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
using Contraloria.Clases.LogicaNegocio;

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
        public String InsertarEstado(Estado elEstado) 
        {
            miComando.CommandText = "SPR_Cat_Estado_insertar";


            miComando.Parameters.Add("@vc_nombreEstado", SqlDbType.VarChar).Value = elEstado.Nombre;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  Estado
        public String ModificarEstado(Estado elEstado)
        {
            miComando.CommandText = "SPR_Cat_Estado_modificar";


            miComando.Parameters.Add("@i_PK_idEstado", SqlDbType.Int).Value = elEstado.Id; ;

            miComando.Parameters.Add("@vc_nombreEstado", SqlDbType.VarChar).Value = elEstado.Nombre; ;
            
			miComando.Parameters.Add("@i_activoEstado", SqlDbType.Int).Value = elEstado.Activo;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  Estado
        public Estado  ConsultarEstado(int i_PK_idEstado)
        {
            miComando.CommandText = "SPR_Cat_Estado_Consultar";

            
			miComando.Parameters.Add("@i_PK_idEstado", SqlDbType.Int).Value = i_PK_idEstado;

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataRow elDato = miDataSet.Tables[0].Rows[0];
                Estado  elEstado = new Estado();
                elEstado.Id = int.Parse(elDato["i_PK_idEstado"].ToString());
                elEstado.Nombre = elDato["vc_nombreEstado"].ToString();
                elEstado.Activo = int.Parse(elDato["i_activoEstado"].ToString());

                return elEstado;
            }
            catch
            {
                return null;
            }

        }
		//Listar  Estado
        public List<Estado> ListarEstado(string filtro)
        {
            miComando.CommandText = "SPR_Cat_Estado_Listar";

            miComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
                      

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataTable dtLista = miDataSet.Tables[0];
                List<Estado> laLista = new List<Estado>();
                //
                foreach (DataRow elDato in dtLista.Rows)
                {
                    Estado elEstado = new Estado();
                    elEstado.Id = int.Parse(elDato["id"].ToString());
                    elEstado.Nombre = elDato["nombre"].ToString();
                    elEstado.Activo = int.Parse(elDato["activo"].ToString());
                    laLista.Add(elEstado);
                 
                }
                return laLista;
            }
            catch
            {
                return null;
            }

        }
    }
}
