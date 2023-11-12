<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="display-2 custom-heading"">VENTAS   </h1>       
    <asp:GridView ID="dgvVentas"  runat="server" CssClass="table" DataKeyNames="IDProdcuto" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged"
        >
    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        <asp:BoundField headerText="Precio" DataField="Precio" DataFormatString="{0:C}" />
        <asp:CommandField ShowSelectButton="true" SelectText="Eliminar Producto" HeaderText="Acción" /> 
        

    </Columns>
      
         
</asp:GridView> 
        <asp:Button runat="server" Text="Button"  OnClick="BtnFactura_Click"/>


</asp:Content>
