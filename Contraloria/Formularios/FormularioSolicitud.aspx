<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSolicitud.aspx.cs" Inherits="Contraloria.Formularios.FormularioSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Formulario Contraloría de Servicios</h2>
    <div>
    <h4 class=" alert-info">Datos de usuario</h4>  
    </div>
  <div class="row">
    <div class="col-xs-2"  >Identificación: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_identificacion" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>
         
  <div class="row">
    <div class="col-xs-2"  >Nombre: </div>
    <div class="col-xs-10" > <asp:TextBox ID="txt_Nombre" CssClass="form-control" runat="server"></asp:TextBox> </div>
  </div>
<h4 class=" alert-info">Medios de Notificación</h4> 
    <div class="row ">

    <div class="col-xs-10" >  <asp:DropDownList ID="cmb_estado" runat="server">
            <asp:ListItem Value="0">--Seleccione--</asp:ListItem>
            </asp:DropDownList>
         <div class="col-xs-10" > </div>
        <asp:TextBox ID="txt_Valor" runat="server"></asp:TextBox>
        <asp:Button ID="btn_Agregar" runat="server" Text="Agregar" CssClass="buttonborder"  />
    </div>
 
    <div class="col-xs-10" >        <asp:GridView ID="grdMedioNotificacion" CssClass="table" runat="server" Width="215px" AutoGenerateColumns="False" CellPadding="5"  BorderStyle="Groove">
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
    </div>



  </div>






</asp:Content>
