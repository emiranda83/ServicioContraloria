<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CtlFileUploader.ascx.cs" Inherits="SIVE_WEB.Formularios.Control.CtlFileUploader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Panel ID="pnlFileUploader" runat="server" GroupingText="Documentos adjuntos" BorderWidth="1">

<asp:Label ID="labelFileUpload" runat="server" Text="Seleccione el Archivo"></asp:Label>&nbsp;
<asp:FileUpload ID="fileupload" runat="server" />&nbsp;<br /> Descripción &nbsp;<asp:TextBox
    ID="txbDocumentoDescripcion" runat="server" Width="298px"></asp:TextBox>
<asp:ImageButton ID="btnUploadFile" runat="server" 
    ImageUrl="~/Imagenes/btnGuardar.png" Height="30px" Width="90px" 
    onclick="btnUploadFile_Click" Visible="False" />
    <asp:Button ID="btnSubir" runat="server" Text="Subir" OnClick="btnSubir_Click" CssClass="btn btn-primary" />
    <br /><asp:Label ID="lblErrorDocumento" 
        runat="server" ForeColor="Red"></asp:Label>
      <%if (dgvListadoAdjuntos.Rows.Count == 0)
        { %>
    <asp:Label ID="lblNoHayRegistros" runat="server" Text="No hay documentos adjuntos" CssClass="btn btn-danger"></asp:Label>
    <%} %>
<asp:GridView ID="dgvListadoAdjuntos" runat="server" ForeColor="#333333" 
        Height="16px" OnPageIndexChanging="gvListadoAdjuntos_PageIndexChanging"
        OnSelectedIndexChanging="gvListadoAdjuntos_SelectedIndexChanging" 
    PageSize="15" Width="718px" AutoGenerateColumns="False" 
        onrowdeleting="dgvListadoAdjuntos_RowDeleting">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:CommandField ShowSelectButton="True" SelectText="Ver Archivo" ItemStyle-CssClass="btn btn-primary"  />
        <asp:CommandField ShowDeleteButton="True" ItemStyle-CssClass="btn btn-danger" />
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Nombre" HeaderText="Archivo" />
          <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
          <asp:BoundField DataField="Extension" HeaderText="Extension" />
        
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="Blue" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
</asp:Panel>