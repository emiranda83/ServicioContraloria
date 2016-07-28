<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantEstado.aspx.cs" Inherits="Contraloria.Formularios.MantEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script type ="text/javascript">
        $(document).ready(function () {
            function MostrarDivNuevo() {
                $("#divNuevoEstado").removeClass("esconderElemento");
                $("#divNuevoEstado").addClass("mostrarElemento");
            }
            function OcultarDivNuevo() {
                $("#divNuevoEstado").removeClass("mostrarElemento");
                $("#divNuevoEstado").addClass("esconderElemento");

            } 
});
</script>


     <h2><%: Title %>Mantenimiento Estado</h2>
    <div class="container-fluid">
  
  
  <div class="row">
    <div class="col-xs-2"  >Filtro: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_Filtro" CssClass="form-control" runat="server"></asp:TextBox></div>
  </div>
  <div class="row">
    <div class="col-xs-2"  >
        </div>
    <div ID= "nuevo"class="col-xs-10"  >  <asp:Button ID="btn_Buscar" runat="server" Text="Buscar" OnClick="btn_Buscar_Click" /> 
           <asp:Button ID="btn_Nuevo" runat="server" Text="Nuevo" OnClick="btn_Nuevo_Click"  /></div>
  </div>
 
</div>
 




      <div id="divNuevoEstado"   class ="container show-top-margin separate-rows tall-rows esconderElemento"  >
  <h4>Mantenimiento Nuevo/Modificar</h4>
  
  <div class="row">
    <div class="col-xs-2"  >Id: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_Id" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>
   
       
  <div class="row">
    <div class="col-xs-2"  >Nombre: </div>
    <div class="col-xs-10" > <asp:TextBox ID="txt_estado" CssClass="form-control" runat="server"></asp:TextBox> </div>
  </div>

           
  <div class="row ">
    <div class="col-xs-2"  >Estado: </div>
    <div class="col-xs-10" >  <asp:DropDownList ID="cmb_estado" runat="server">
            <asp:ListItem Value="0">Inactivo</asp:ListItem>
            <asp:ListItem Value="1">Activo</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>

           
  <div class="row">
    <div class="col-xs-2"  > </div>
    <div class="col-xs-10" >  <asp:Button ID="btn_Guardar" runat="server" Text="Guardar" OnClick="btn_Guardar_Click" /> </div>
  </div>
        <div class="row">
    <div class="col-xs-2"  > </div>
    <div class="col-xs-10" >   </div>
  </div>
      </div>

   
      
         <asp:GridView ID="grdEstado" CssClass="table" runat="server" AllowPaging="True" Width="215px" AutoGenerateColumns="False" CellPadding="10" OnSelectedIndexChanging="grdEstado_SelectedIndexChanging">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" ControlStyle-CssClass ="btn btn-primary" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Estado" />
                <asp:BoundField DataField="EstadoMostrar" HeaderText="Estado" />
            </Columns>
            </asp:GridView>
    

</asp:Content>

