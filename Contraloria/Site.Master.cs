using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.UI.HtmlControls;
using Componentes.Sistemas.Clases;

namespace Contraloria
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            Conexion.laConexion.Usuario = "sercontra_ow";
            Conexion.laConexion.Contrasena = "cntr.0716";
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        public void CargarErrores(List<string> errores)
        {

            blErrores.DataSource = errores;
            blErrores.DataBind();
            if (errores.Count > 0)
            {
                lblError.Visible = true;
                blErrores.Visible = true;
                MostrarMensaje("Se encontraron errores en el formulario", true);
            }
            else
                lblError.Visible = false;
        }
        public void LimpiarErrores()
        {
            // blErrores.ClearSelection();
            blErrores.DataSource = null;
            blErrores.DataBind();
            blErrores.Visible = false;
            lblError.Visible = false;

        }

        public void MostrarMensaje(string mensaje, bool tipoError = false)
        {
            HtmlControl divError = FindControl("divMensajeError") as HtmlControl;
            divError.Attributes["class"] = "alert alert-danger esconderElemento";
            lblMensajeError.Text = "";

            HtmlControl divCorrecto = FindControl("divMensajeCorrecto") as HtmlControl;
            divCorrecto.Attributes["class"] = "alert alert-success esconderElemento";
            lblMensajeCorrecto.Text = "";


            //cambiar caracteres
            mensaje = mensaje.Replace("'", "");
            if (tipoError)
            {// es un mensaje de error 
                lblMensajeError.Text = mensaje;
                divError.Attributes["class"] = "alert alert-danger mostrarElemento";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.options.positionClass = 'toast-top-full-width';toastr.error('" + mensaje + "', '');", true);
            }
            else
            {
                lblMensajeCorrecto.Text = mensaje;
                divCorrecto.Attributes["class"] = "alert alert-success mostrarElemento";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.options.positionClass = 'toast-top-full-width';toastr.success('" + mensaje + "', '');", true);
            }
            //Response.Write(@"<script language='JavaScript' type='text/javascript'>alert('" + p + "');</script>");
        }
        public void MostrarMensajeInfo_Toastr(string mensaje)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.options.positionClass = 'toast-top-full-width';toastr.info('" + mensaje + "', '');", true);
        }

    }

}