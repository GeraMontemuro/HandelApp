<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarCompra.aspx.cs" Inherits="HandelApp.EditarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="display-2 custom-heading">EDITAR COMPRA </h1>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Fecha" />
        <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control txtBox" />
        <asp:CompareValidator runat="server" ControlToValidate="txtFecha" Operator="DataTypeCheck" Type="Date"
            ErrorMessage="La fecha seleccionada no es válida." Text="*" Display="Dynamic" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Producto" />
        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" Width="500px" AutoPostBack="true"></asp:DropDownList>
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Cantidad" />
        <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCantidad"
            ErrorMessage="La cantidad debe ser un número entero, mayor a cero"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Precio de Compra" />
        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control txtBox" />
        <asp:RangeValidator runat="server" ControlToValidate="txtPrecio"
            ErrorMessage="El precio de compra debe ser númerico y mayor a cero"
            Display="Dynamic"
            MinimumValue="0"
            Type="Double"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Proveedor" />
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" Width="500px" AutoPostBack="true"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="btnGuardarCambios" CssClass="btn btn-success" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambios_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
