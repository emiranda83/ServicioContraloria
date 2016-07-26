
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
using Contraloria.Clases.LogicaNegocio;

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
        public String InsertarTramite(Tramite elTramite)
        {
            miComando.CommandText = "SPR_Cat_Tramite_insertar";


            miComando.Parameters.Add("@vc_NombreTramite", SqlDbType.VarChar).Value = elTramite.Nombre;            
            

            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Modificar  Tramite
        public String ModificarTramite(Tramite elTramite)
        {//int i_PK_idTramite,string vc_NombreTramite,int i_activoTramite
            miComando.CommandText = "SPR_Cat_Tramite_modificar";

            
			miComando.Parameters.Add("@i_PK_idTramite", SqlDbType.Int).Value = elTramite.Id;
            
			miComando.Parameters.Add("@vc_NombreTramite", SqlDbType.VarChar).Value = elTramite.Nombre;
            
			miComando.Parameters.Add("@i_activoTramite", SqlDbType.Int).Value = elTramite.Estado;
            
            
            
            respuesta = this.ejecutaSentencia(miComando);
            if (respuesta == "") respuesta = respuestaCorrecta;
            return respuesta;

        }
		//Consultar  Tramite
        public Tramite ConsultarTramite(int i_PK_idTramite)
        {
            miComando.CommandText = "SPR_Cat_Tramite_Consultar";

            
			miComando.Parameters.Add("@i_PK_idTramite", SqlDbType.Int).Value = i_PK_idTramite;

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataRow elDato= miDataSet.Tables[0].Rows[0];
                Tramite elTramite = new Tramite();
                elTramite.Id = int.Parse(elDato["i_PK_idTramite"].ToString());
                elTramite.Nombre = elDato["vc_NombreTramite"].ToString();
                elTramite.Estado= int.Parse(elDato["i_activoTramite"].ToString());


                //2

                //Tramite elTramite2 = new Tramite(int.Parse(elDato["i_PK_idTramite"].ToString()), elDato["vc_NombreTramite"].ToString(),int.Parse(elDato["i_activoTramite"].ToString());
                return elTramite;
            }
            catch
            {
                return null;
            }

        }
		//Listar  Tramite
        public List<Tramite> ListarTramite(string filtro)
        {
            miComando.CommandText = "SPR_Cat_Tramite_Listar";

            miComando.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro;
            
            

            try
            {
                DataSet miDataSet = new DataSet();
                this.abrirConexion();
                miDataSet = this.seleccionarInformacion(miComando);
                this.cerrarConexion();
                DataTable dtLista= miDataSet.Tables[0];
                List<Tramite> laLista = new List<Tramite>();
                //
                foreach (DataRow elDato in dtLista.Rows)
                {
                    Tramite elTramite = new Tramite();
                    elTramite.Id = int.Parse(elDato["id"].ToString());
                    elTramite.Nombre = elDato["nombre"].ToString();
                    elTramite.Estado = int.Parse(elDato["estado2"].ToString());
                    laLista.Add(elTramite);
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
