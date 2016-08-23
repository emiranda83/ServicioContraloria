<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Contraloria.Formularios.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <h2><%: Title %>Registro Usuarios</h2>
    <div class="container-fluid">
  
  
  <div class="row">
    <div class="col-xs-2"  > Identificación: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_Identificacion" CssClass="form-control" runat="server"></asp:TextBox></div>
  </div>
<div class="row">
    <div class="col-xs-2"  >Nombre: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_Nombre" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>

<div class="row">
    <div class="col-xs-2"  > </div>
    <div class="col-xs-10" >  <asp:Button ID="btn_Registro" runat="server" Text="Registrar" OnClick="btn_Registro_Click" CssClass="buttonborder"  />
         <asp:Button ID="btn_Cancelar" runat="server" Text="Cancelar"  CssClass="buttonborder"  /></div>
</div>
    






  </div>  
</asp:Content>
