<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSolicitud.aspx.cs" Inherits="Contraloria.Formularios.FormularioSolicitud" %>
<%@ Register src="../Controllers/CtlFileUploader.ascx" tagname="CtlFileUploader" tagprefix="uc1" %>
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
<%--****Calendario****--%>
   <script>
    $( function() {

    $( "#datepicker" ).datepicker();

    } );

  </script>
<%--****Confidencialidad****--%>
     <div class="row ">
    <div class="col-xs-10 col-md-10" >  
        <h4 class="alert-info">Acuerdo Confidencialidad</h4>
        <p>Confidencialidad<asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Value="0">No</asp:ListItem>
            <asp:ListItem Value="1">Si</asp:ListItem>
            </asp:CheckBoxList>
&nbsp;</p>
    </div>
   </div>

<%--****Adjuntos****--%>
 <div class="row">

    <div class="col-xs-10 col-md-10"> 
        <h4 class=" alert-info">Adjuntos</h4>
    </div>
    <div class="col-xs-10 col-md-10" >  
        <asp:FileUpload ID="archivoSeleccionado" runat="server" />
     <asp:Button ID="btnSubir" runat="server" Text="Subir" OnClick="btnSubir_Click" />
     </div>
      </div>
     <div class="row">

    <div class="col-xs-10 col-md-10"> 
    </div>
         </div>




  
   
</asp:Content>
