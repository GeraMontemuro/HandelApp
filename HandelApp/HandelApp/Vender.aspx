<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="display-2 custom-heading"">VENTAS   </h1>       
    
    <asp:GridView ID="dgvVentas" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged">
        <Columns>
            <%--<asp:BoundField HeaderText="Id" DataField="IDProducto" />--%>
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Stock Total" DataField="StockTotal" />
            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
            <asp:BoundField HeaderText="Precio Venta" DataField="PrecioVenta" DataFormatString="{0:C}"/>
            <asp:BoundField HeaderText="Precio Compra" DataField="PrecioCompra" DataFormatString="{0:C}" />

        </Columns>
        </asp:GridView>

</asp:Content>
