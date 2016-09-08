using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SENASA.ContraloriaServicios.Integracion.Integracion.Solicitud;
using SENASA.ContraloriaServicios.Logica.Servicios.Solicitud;
using Contraloria.Clases.LogicaNegocio;

namespace Contraloria.Formularios
{
    public partial class FormularioSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            string respuesta;
            GestorAdjunto elServicio = new GestorAdjunto();
            Adjunto elAdjunto = new Adjunto();

            //Con esta condición nos aseguramos de dos cosas, primero que el se haya realizado la carga o la transferencia de un archivo ya que con PostedFile se recupera la información relacionada al archivo (tamaño, tipo, contenido, etc.) y en segundo lugar que el arreglo contenga al menos un archivo cargado.
            if ((archivoSeleccionado.PostedFile != null) &&
            (archivoSeleccionado.PostedFile.ContentLength > 0))
            {
                
                //Con la clase HttpPostedFile se obtiene acceso de forma individual a los archivos cargados
                HttpPostedFile imgFile = archivoSeleccionado.PostedFile;

                //Creamos byteFile que contendrá todo el contenido del archivo
                Byte[] byteFile = new Byte[archivoSeleccionado.PostedFile.ContentLength];

                //Se lee el contenido del archivo en la variable creada byteFile
                imgFile.InputStream.Read(byteFile, 0, archivoSeleccionado.PostedFile.ContentLength);
                elAdjunto.Imagen = byteFile;
                elAdjunto.Descripcion = txtdescripcionAdjunto.Text;
                elAdjunto.Tipo= archivoSeleccionado.PostedFile.ContentType;
                respuesta = elServicio.InsertarAdjunto(elAdjunto.Imagen, elAdjunto.Descripcion, elAdjunto.Tipo);
            }
        }
    }
}