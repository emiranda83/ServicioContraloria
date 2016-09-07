using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Contraloria.Formularios
{
    public partial class FormularioSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
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

                //Se crea la sentencia SQL que insertará los datos en la tabla de la BD
                string sql = “insert into tblArchivos(Image, Tipo) values(@Archivo, @Tipo)”;

                //Se crea el recurso de conexión a la BD, la cadena de conexión varia de acuerdo a los parámetros establecidos por su conexión al gestor, usuario, contraseña y método de conexión.
                SqlConnection conn = new SqlConnection(“String de conexión al gestor y a la BD.”);

                //Se crea el recurso de Command que permitirá ejecutar la instrucción SQL.
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(“@Archivo”, System.Data.SqlDbType.Image);
                cmd.Parameters.Add(“@Tipo”, System.Data.SqlDbType.VarChar, 50);
                cmd.Parameters[“@Archivo”].Value = byteFile;
                cmd.Parameters[“@Tipo”].Value = archivoSeleccionado.PostedFile.ContentType;

                //se abre la conexión al gestor de BD y se hace la ejecución de la sentencia
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
        }
    }
}