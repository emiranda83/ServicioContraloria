
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
using Contraloria.Clases.LogicaNegocio;

namespace  SENASA.ContraloriaServicios.Logica.Servicios.Catalogo
{
    public class ServicioMedioNotificacion : Servicio, IDisposable
    {
        
        public ServicioMedioNotificacion()
        {
            
        }
        public void Dispose()
        { }

		//Inserta  MedioNotificacion
        public String InsertarMedioNotificacion(MedioNotificacion elMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_insertar";


            miComando.Parameters.Add("@vc_NombreMedio", SqlDbType.VarChar).Value = elMedio.Nombre;
            
			     
            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  MedioNotificacion
        public String ModificarMedioNotificacion(MedioNotificacion elMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_modificar";


            miComando.Parameters.Add("@i_PK_idMedio", SqlDbType.Int).Value = elMedio.Id;

            miComando.Parameters.Add("@vc_NombreMedio", SqlDbType.VarChar).Value = elMedio.Nombre;

            miComando.Parameters.Add("@i_activoMedio", SqlDbType.Int).Value = elMedio.Estado;
            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  MedioNotificacion
        public MedioNotificacion ConsultarMedioNotificacion(int i_PK_idMedio)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_Consultar";

            
			miComando.Parameters.Add("@i_PK_idMedio", SqlDbType.Int).Value = i_PK_idMedio;

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataRow elDato= miDataSet.Tables[0].Rows[0];
                MedioNotificacion elMedio = new MedioNotificacion();
                elMedio.Id = int.Parse(elDato["i_PK_idMedio"].ToString());
                elMedio.Nombre = elDato["vc_NombreMedio"].ToString();
                elMedio.Estado = int.Parse(elDato["i_activoMedio"].ToString());

                return elMedio;


            }
            catch
            {
                return null;
            }

        }
		//Listar  MedioNotificacion
        public List<MedioNotificacion> ListarMedioNotificacion(string filtro)
        {
            miComando.CommandText = "SPR_Cat_MedioNotificacion_Listar";

            miComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
            
            

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataTable dtLista = miDataSet.Tables[0];
                List<MedioNotificacion> laLista = new List<MedioNotificacion>();
                
                foreach (DataRow elDato in dtLista.Rows)
                {
                    MedioNotificacion elMedio = new MedioNotificacion();
                    elMedio.Id= int.Parse(elDato["id"].ToString());
                    elMedio.Nombre = elDato["nombreMedio"].ToString();
                    elMedio.Estado = int.Parse(elDato["activoMedio2"].ToString());
                    laLista.Add(elMedio);
                }



                return laLista;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
