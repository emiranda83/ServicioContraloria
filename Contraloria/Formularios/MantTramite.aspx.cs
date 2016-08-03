using Componentes.Sistemas.Clases;
using Contraloria.Clases.LogicaNegocio;
using SENASA.ContraloriaServicios.Integracion.Integracion.Catalogo;
using SENASA.ContraloriaServicios.Logica.Servicios.Catalogo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
namespace Contraloria.Formularios
{
    public partial class MantTramite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

             

                CargarTramite();
            }
        }

        private void CargarTramite()
        {
            using (ServicioTramite elServicio = new ServicioTramite())
            grdTramite.DataSource= elServicio.ListarTramite(txt_Filtro.Text);
            grdTramite.DataBind();

        }

        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ((SiteMaster)this.Master).MostrarMensaje("Bueno");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            CargarTramite();
        }

        protected void grdTramite_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Tramite elTramite = null;
            string respuesta = "";
            using (GestorTramite elGestor = new GestorTramite())
                elTramite = elGestor.ConsultarTramite(int.Parse(grdTramite.Rows[e.NewSelectedIndex].Cells[1].Text));
            if (elTramite != null)
            {
                txt_Id.Text = elTramite.Id.ToString();
                txt_tramite.Text = elTramite.Nombre;
                cmb_estado.SelectedValue = elTramite.Estado.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoTramite').removeClass('esconderElemento');$('#divNuevoTramite').addClass('mostrarElemento');});", true);
            }


        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            string respuesta;
            
            {
                GestorTramite elServicio = new GestorTramite();
                if (txt_Id.Text == "")
                {
                    Tramite elTramite = new Tramite();
                    respuesta = elServicio.InsertarTramite(txt_tramite.Text);
                    CargarTramite();
                    

                }
                else
                    respuesta = elServicio.ModificarTramite(int.Parse(txt_Id.Text), txt_tramite.Text, int.Parse(cmb_estado.SelectedValue));

                if (respuesta.Equals(Componentes.Sistemas.Clases.Global.elGlobal.RespuestaCorrecta))
                {
                    
                        ((SiteMaster)this.Master).MostrarMensaje("Datos Guardados");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoTramite').removeClass('mostrarElemento');$('#divNuevoTramite').addClass('esconderElemento');});", true);
                    //limpiar
                    CargarTramite();
                    

                }
                else
                {
                    ((SiteMaster)this.Master).MostrarMensaje("Error al insertar datos: "+respuesta, true);

                }


            }
        }

        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoTramite').removeClass('esconderElemento');$('#divNuevoTramite').addClass('mostrarElemento');});", true);

        }

     
    }
}