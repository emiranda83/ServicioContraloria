<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantMedios.aspx.cs" Inherits="Contraloria.Formularios.MantMedios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
     <h2><%: Title %>Mantenimiento Medios de Notificación</h2>
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
 




      <div id="divNuevoMedio"   class ="container show-top-margin separate-rows tall-rows esconderElemento"  >
  <h4>Mantenimiento Nuevo/Modificar</h4>
  
  <div class="row">
    <div class="col-xs-2"  >Id: </div>
    <div class="col-xs-10" ><asp:TextBox ID="txt_Id" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>  </div>
  </div>
   
       
  <div class="row">
    <div class="col-xs-2"  >Medio: </div>
    <div class="col-xs-10" > <asp:TextBox ID="txt_Medio" CssClass="form-control" runat="server"></asp:TextBox> </div>
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
         <asp:GridView ID="grdMedio" CssClass="table" runat="server" AllowPaging="True" Width="215px" AutoGenerateColumns="False" CellPadding="10" OnSelectedIndexChanging="grdMedio_SelectedIndexChanging" BorderStyle="Groove" >
             <AlternatingRowStyle BackColor="#E3F2FD" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Editar" ControlStyle-CssClass ="btn btn-primary" >
<ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="Id" HeaderText="ID" >
                <HeaderStyle ForeColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Medio de Notificación" >
                <HeaderStyle ForeColor="White" />
                </asp:BoundField>
                <asp:BoundField DataField="EstadoMostrar" HeaderText="Estado" >
                <HeaderStyle ForeColor="White" />
                </asp:BoundField>
            </Columns>
             <HeaderStyle BackColor="#1565C0" />
            </asp:GridView>
</asp:Content>
