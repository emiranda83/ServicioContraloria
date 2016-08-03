<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSolicitud.aspx.cs" Inherits="Contraloria.Formularios.FormularioSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Formulario Contraloría de Servicios</h2>
  
  <div class="row">
    <div class="col-xs-2"  >Su nombre: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_nombre" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>
   
       
  <div class="row">
    <div class="col-xs-2"  >Nombre: </div>
    <div class="col-xs-10" > <asp:TextBox ID="txt_tramite" CssClass="form-control" runat="server"></asp:TextBox> </div>
  </div>







</asp:Content>
