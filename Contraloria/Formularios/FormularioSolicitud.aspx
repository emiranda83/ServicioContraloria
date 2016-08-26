<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSolicitud.aspx.cs" Inherits="Contraloria.Formularios.FormularioSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
      <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
      


    <h2>Formulario Contraloría de Servicios</h2>
     <div class="container-fluid">

<%--*** Datos de Usuario *** --%>            
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

<%--*** Escoger los medios de notirficación, pueden ser varios *** --%>
<div class="row ">
    <div class="col-xs-10 col-md-10" >  
<h4 class=" alert-info">Medios de Notificación</h4> </div>
 </div>
    
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
 
<%--*** El grid se deja por fuera de los div *** --%>
 
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

<%--*** Escoger el tipo de trámite*** --%>
    <div class="row ">
    <div class="col-xs-10 col-md-10" >  
        <h4 class=" alert-info">Tipo de Trámite</h4>
    </div>
    </div>
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
   </div>

<%--*** Descripción de la Solicitud*** --%>
  <div class="row ">
    <div class="col-xs-10 col-md-10" >  
        <h4 class=" alert-info">Descripción</h4>
    </div>
   </div>

  <div class="row ">
    <div class="col-xs-10 col-md-10" >    
        <asp:TextBox ID="txt_Descripcion"  runat="server" Height="100px" TextMode="MultiLine" Width="709px"></asp:TextBox>  
   
  </div>
  </div>
   <div class="row">
         
    <div class="col-xs-10" >   <p>Fecha <input type="text" id="datepicker"></p>             </div>
     
  </div> 
   

</div>

   <script>
    $( function() {

    $( "#datepicker" ).datepicker();

    } );

  </script>
     <div class="row ">
    <div class="col-xs-10 col-md-10" >  
        <h4 class=" alert-info">Documentos Adjuntos</h4>
    </div>
   </div>
 <div class="row">

    <div class="col-xs-2">Seleccione el Archivo </div>
    <div class="col-xs-10" ><asp:TextBox ID="TextBox1" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>



  
   
</asp:Content>
