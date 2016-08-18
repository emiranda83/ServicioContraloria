using SENASA.ContraloriaServicios.Logica.Servicios.Catalogo;
using Contraloria.Clases.LogicaNegocio;
using SENASA.ContraloriaServicios.Integracion.Integracion.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contraloria.Formularios
{
    public partial class MantMedios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
               CargarMedio();
            }
        }


        private void CargarMedio()
        {
            using (ServicioMedioNotificacion elServicio = new ServicioMedioNotificacion())
                grdMedio.DataSource = elServicio.ListarMedioNotificacion(txt_Filtro.Text);
                grdMedio.DataBind();

        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            CargarMedio();
        }
        /*****************************Llenado del Grid*********************************************/
        protected void grdMedio_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            MedioNotificacion elMedio = null;
            using (GestorMedioNotificacion elGestor = new GestorMedioNotificacion())
                elMedio = elGestor.ConsultarMedioNotificacion(int.Parse(grdMedio.Rows[e.NewSelectedIndex].Cells[1].Text));
            if (elMedio != null)
            {
                txt_Id.Text = elMedio.Id.ToString();
                txt_Medio.Text = elMedio.Nombre.ToString();
                cmb_estado.SelectedValue = elMedio.Estado.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoMedio').removeClass('esconderElemento');$('#divNuevoMedio').addClass('mostrarElemento');});", true);
            }
        }

        protected void btn_Guardar_Click(object sender, EventArgs e)
        {
            string respuesta;

            GestorMedioNotificacion elServicio = new GestorMedioNotificacion();
            if (txt_Id.Text == "")
            {
                MedioNotificacion Medio = new MedioNotificacion();
                respuesta = elServicio.InsertarMedioNotificacion(txt_Medio.Text);
                CargarMedio();
            }
            else
                respuesta = elServicio.ModificarMedioNotificacion(int.Parse(txt_Id.Text), txt_Medio.Text, int.Parse(cmb_estado.SelectedValue));
            if (respuesta.Equals(Componentes.Sistemas.Clases.Global.elGlobal.RespuestaCorrecta))
            {

                ((SiteMaster)this.Master).MostrarMensaje("Datos Guardados");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoMedio').removeClass('mostrarElemento');$('#divNuevoMedio').addClass('esconderElemento');});", true);
                //limpiar
                CargarMedio();


            }
            else
            {
                ((SiteMaster)this.Master).MostrarMensaje("Error al insertar datos: " + respuesta, true);

            }

        
        }

        protected void btn_Nuevo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(document).ready(function () {  $('#divNuevoMedio').removeClass('esconderElemento');$('#divNuevoMedio').addClass('mostrarElemento');});", true);
        }
    }
}