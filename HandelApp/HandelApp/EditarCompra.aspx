<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarCompra.aspx.cs" Inherits="HandelApp.EditarCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>EDITAR COMPRA </h1>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Fecha" />
    <asp:TextBox runat="server" ID="txtFecha" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Producto" />
    <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Cantidad" />
    <asp:TextBox runat="server" ID="txtCantidad" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Precio de Compra" />
    <asp:TextBox runat="server" ID="txtPrecio" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Proveedor" />
    <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
</div>


    <div class="modal-footer">
    <asp:Button ID="btnGuardarCambios" CssClass="btn btn-success" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambios_Click" />
    <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
