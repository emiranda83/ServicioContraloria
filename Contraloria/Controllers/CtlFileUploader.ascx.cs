using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIVE_WEB.Clases.Controller.Utilidades;
using SIVE_WEB.Clases.Logica;
using System.IO;
using System.Drawing;

namespace SIVE_WEB.Formularios.Control
{
    public partial class CtlFileUploader : System.Web.UI.UserControl
    {
        DocumentoAdjuntoController elDocAdjCo = new DocumentoAdjuntoController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Entidad_Id == 0)
            {// ocultar esta creando una nueva entidad
                pnlFileUploader.Visible = false;
            }
            else
            {//mostrar el control
                pnlFileUploader.Visible = true;

            }

            if (!this.Page.IsPostBack)
            {
                CargarListado();
            }
        }
        private string entidad="";

        public string Entidad
        {
            get { return entidad; }
            set { entidad = value; }
        }
        private int entidad_Id=0;

        public int Entidad_Id
        {
            get { return entidad_Id; }
            set { entidad_Id = value;
            MostrarControl();
            }
        }

        public void MostrarControl()
        {
            pnlFileUploader.Visible = true;
        }

        protected void btnUploadFile_Click(object sender, ImageClickEventArgs e)
        {
            
        }

            private void CargarListado()
            {
                dgvListadoAdjuntos.DataSource = elDocAdjCo.ObtenerDocumentoAdjuntos("", entidad,entidad_Id);
                dgvListadoAdjuntos.DataBind();
                if (elDocAdjCo.Errores.Count > 0)
                {
                    lblErrorDocumento.Text ="Error al cargar listado:"+ elDocAdjCo.Errores[0];
                }
            }

            protected void gvListadoAdjuntos_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
                dgvListadoAdjuntos.PageIndex = e.NewPageIndex;
                CargarListado();
            }

            protected void gvListadoAdjuntos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
            {
                DocumentoAdjunto elDocumentoAdjunto = elDocAdjCo.Obtener(int.Parse(dgvListadoAdjuntos.Rows[e.NewSelectedIndex].Cells[2].Text));

                Response.Clear();
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", elDocumentoAdjunto.Nombre));

                switch (Path.GetExtension(elDocumentoAdjunto.Nombre).ToLower())
                {
                    case ".jpg":
                        Response.ContentType = "image/jpg";
                        break;
                    case ".gif":
                        Response.ContentType = "image/gif";
                        break;
                    case ".png":
                        Response.ContentType = "image/png";
                        break;
                    case ".bm":
                        Response.ContentType = "image/bmp";
                        break;
                    case ".bmp":
                        Response.ContentType = "image/bmp";
                        break;
                    case ".doc":
                        Response.ContentType = "application/msword";
                        break;
                    case ".dot":
                        Response.ContentType = "application/msword";
                        break;
                    case ".htm":
                        Response.ContentType = "text/html";
                        break;
                    case ".html":
                        Response.ContentType = "text/html";
                        break;
                    case ".htmls":
                        Response.ContentType = "text/html";
                        break;
                    case ".jpeg":
                        Response.ContentType = "image/jpeg";
                        break;
                    case ".pdf":
                        Response.ContentType = "application/pdf";
                        break;
                    case ".svf":
                        Response.ContentType = "image/vnd.dwg";
                        break;
                    case ".svr":
                        Response.ContentType = "application/x-world";
                        break;
                    case ".text":
                        Response.ContentType = "text/plain";
                        break;
                    case ".txt":
                        Response.ContentType = "text/plain";
                        break;
                    case ".xl":
                        Response.ContentType = "application/excel";
                        break;
                    case ".xls":
                        Response.ContentType = "application/excel";
                        break;
                    case ".xml":
                        Response.ContentType = "application/xml";
                        break;
                    case ".zip":
                        Response.ContentType = "application/x-zip-compressed";
                        break;
                    case ".word":
                        Response.ContentType = "application/msword";
                        break;
                    case ".vsd":
                        Response.ContentType = "application/x-visio";
                        break;
                    case ".vst":
                        Response.ContentType = "application/x-visio";
                        break;
                    case ".vsw":
                        Response.ContentType = "application/x-visio";
                        break;
                    case ".asp":
                        Response.ContentType = "text/asp";
                        break;
                    case ".exe":
                        Response.ContentType = "application/octet-stream";
                        break;
                    case ".docx":
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;
                    case ".xlsx":
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        break;
                }

                Response.BinaryWrite(elDocumentoAdjunto.Documento);
                Response.End();
            }

            protected void dgvListadoAdjuntos_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                elDocAdjCo.EliminarDocumentoAdjunto(int.Parse(dgvListadoAdjuntos.Rows[e.RowIndex].Cells[2].Text), ((Funcionario)Session["siveUser"]).Id);
                if (elDocAdjCo.Errores.Count > 0)
                {
                    lblErrorDocumento.Text = elDocAdjCo.Errores[0];
                    lblErrorDocumento.ForeColor = Color.Red;
                }
                else
                {
                    lblErrorDocumento.Text = "Eliminado correctamente";
                    lblErrorDocumento.ForeColor = Color.Green;
                    CargarListado();
                }
            }

            protected void btnSubir_Click(object sender, EventArgs e)
            {
                if (fileupload.HasFile)
                {
                    elDocAdjCo.InsertaDocumentoAdjunto(entidad, entidad_Id, fileupload.FileName.Replace(" ", "_").Replace("ñ", "n").Replace("Ñ", "N"), fileupload.FileBytes, txbDocumentoDescripcion.Text, ((Funcionario)Session["siveUser"]).Id, fileupload.FileBytes.Count());
                    if (elDocAdjCo.Errores.Count > 0)
                    {
                        lblErrorDocumento.Text = elDocAdjCo.Errores[0];
                    }
                    else
                    {

                        lblErrorDocumento.Text = "Transacción efectuada correctamente!";
                        lblErrorDocumento.ForeColor = Color.Green;
                        txbDocumentoDescripcion.Text = "";
                        CargarListado();
                    }
                }
                else
                {
                    lblErrorDocumento.Text = "Debe seleccionar un documento";
                    lblErrorDocumento.ForeColor = Color.Red;
                }
            }
        }
}