<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSolicitud.aspx.cs" Inherits="Contraloria.Formularios.FormularioSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Formulario Contraloría de Servicios</h2>
     <div class="container-fluid">
    <div class="row ">
        <div class="col-xs-10">
    <h4 class=" alert-info">Datos de usuario</h4>  
    </div>
</div>
  <div class="row">

    <div class="col-xs-2">Identificación: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_identificacion" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>
         
  <div class="row">
    <div class="col-xs-2"  >Nombre: </div>
    <div class="col-xs-10" > <asp:TextBox ID="txt_Nombre" CssClass="form-control" runat="server"></asp:TextBox> </div>
  </div>
<div class="row ">
<h4 class=" alert-info">Medios de Notificación</h4> </div>
    <div class="row ">

    <div class="col-xs-10 col-md-10" >  
        <asp:DropDownList ID="cmb_estado" runat="server">
            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
            </asp:DropDownList>
         &nbsp;&nbsp;
        <asp:TextBox ID="txt_Valor" runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="buttonborder"  />
   
    </div>    
        </div>
 
       <asp:GridView ID="grdMedioNotificacion" CssClass="table" runat="server" Width="215px" AutoGenerateColumns="False" CellPadding="5"  BorderStyle="Groove">
             <AlternatingRowStyle BackColor="#E3F2FD" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" ControlStyle-CssClass ="btn btn-primary" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>
                
                <asp:BoundField DataField="Medio" HeaderText="Medio" >
                <HeaderStyle ForeColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="EstadoMostrar" HeaderText="Valor" >
                <HeaderStyle ForeColor="White" />
                </asp:BoundField>
            </Columns>
             <HeaderStyle BackColor="#1565C0" />
            </asp:GridView>

<div class="row ">
<h4 class=" alert-info">Tipo de Trámite</h4> </div>
    <div class="row ">

    <div class="col-xs-10" >  
            <asp:DropDownList ID="cmb_Tramite" runat="server" Width="108px">
            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
            </asp:DropDownList>
     &nbsp;&nbsp;
        <asp:TextBox ID="txt_tramite"  runat="server"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Button ID="btn_AgregarTramite" runat="server" Text="Agregar" CssClass="buttonborder"  />
   
     </div>
         <div class="col-xs-10" >
   
        </div>

  </div>






    </div>
</asp:Content>
