<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="HandelApp.EditarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>EDITAR PRODUCTO </h1>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Nombre" />
    <asp:TextBox runat="server" ID="txtNombre" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Descripción" />
    <asp:TextBox runat="server" ID="txtDescripcion" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Código" />
    <asp:TextBox runat="server" ID="txtCodigo" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Marca" />
    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Categoria" />
    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Stock Total" />
    <asp:TextBox runat="server" ID="txtStockTotal" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Stock Mínimo" />
    <asp:TextBox runat="server" ID="txtStockMinimo" />
</div>

<div style="margin-bottom: 10px;">
    <asp:Label runat="server" Text="Precio de Compra" />
    <asp:TextBox runat="server" ID="txtPrecio" />
</div>

    <div class="modal-footer">
    <asp:Button ID="btnGuardarCambios" CssClass="btn btn-success" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambios_Click" />
    <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
