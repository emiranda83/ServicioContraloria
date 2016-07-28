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
    public partial class MantEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

              
                CargarEstado();
            }
        }

        private void CargarEstado()
        {
            using (ServicioEstado  elServicio = new ServicioEstado())
                grdEstado.DataSource = elServicio.ListarEstado(txt_Filtro.Text);
                grdEstado.DataBind();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ((SiteMaster)this.Master).MostrarMensaje("Bueno");
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            CargarEstado();
        }

        protected void grdEstado_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Estado elEstado = null;
          //  string respuesta = "";
            using (GestorEstado elGestor = new GestorEstado())
                elEstado  = elGestor.ConsultarEstado(int.Parse(grdEstado.Rows[e.NewSelectedIndex].Cells[1].Text));
            if (elEstado!= null)
            {
                txt_Id.Text = elEstado.Id.ToString();
                txt_estado.Text = elEstado.Nombre;
                cmb_estado.SelectedValue = elEstado.Estado1.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoEstado').removeClass('esconderElemento');$('#divNuevoEstado').addClass('mostrarElemento');});", true);
            }


        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            string respuesta;

            {
                GestorEstado  elServicio = new GestorEstado();
                if (txt_Id.Text == "")
                {
                    Estado elEstado = new Estado();
                    respuesta = elServicio.InsertarEstado(txt_estado.Text);
                    CargarEstado();


                }
                else
                    respuesta = elServicio.ModificarEstado(int.Parse(txt_Id.Text), txt_estado.Text, int.Parse(cmb_estado.SelectedValue));

                if (respuesta.Equals(Componentes.Sistemas.Clases.Global.elGlobal.RespuestaCorrecta))
                {

                    ((SiteMaster)this.Master).MostrarMensaje("Datos Guardados");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoEstado').removeClass('mostrarElemento');$('#divNuevoEstado').addClass('esconderElemento');});", true);
                    //limpiar
                    CargarEstado();


                }
                else
                {
                    ((SiteMaster)this.Master).MostrarMensaje("Error al insertar datos: " + respuesta, true);

                }


            }
        }

        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoEstado').removeClass('esconderElemento');$('#divNuevoEstado').addClass('mostrarElemento');});", true);

        }
    }
}