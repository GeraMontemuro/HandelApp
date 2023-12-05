<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoProducto.aspx.cs" Inherits="HandelApp.NuevoProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>NUEVO PRODUCTO </h1>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Nombre" />
        <asp:TextBox runat="server" ID="txtNombre" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNombre"
            ErrorMessage="La longitud del nombre debe estar entre 3 y 50 caracteres"
            Display="Dynamic"
            ValidationExpression="^.{3,50}$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Descripción" />
        <asp:TextBox runat="server" ID="txtDescripcion" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDescripcion"
            ErrorMessage="La longitud de la descripción debe estar entre 3 y 50 caracteres"
            Display="Dynamic"
            ValidationExpression="^.{3,50}$"
            ForeColor="Red" />
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
        <asp:Label runat="server" Text="Categoría" />
        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Stock Total" />
        <asp:TextBox runat="server" ID="txtStockTotal" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtStockTotal"
            ErrorMessage="Stock Total debe ser un número entero"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Stock Mínimo" />
        <asp:TextBox runat="server" ID="txtStockMinimo" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtStockMinimo"
            ErrorMessage="Stock Mínimo debe ser un número entero"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Precio de Compra" />
        <asp:TextBox runat="server" ID="txtPrecio" />
        <asp:RangeValidator runat="server" ControlToValidate="txtPrecio"
            ErrorMessage="El precio de compra debe ser númerico y mayor a cero"
            Display="Dynamic"
            MinimumValue="0"
            Type="Double"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Porcentaje de Ganancia" />
        <asp:TextBox runat="server" ID="txtPorcentaje" />
        <asp:RangeValidator runat="server" ControlToValidate="txtPorcentaje"
            ErrorMessage="El  porcentaje de ganancia debe estar entre 0 y 100"
            Display="Dynamic"
            MinimumValue="0"
            MaximumValue="100"
            Type="Integer"
            ForeColor="Red" />
    </div>

    <div class="modal-footer">
        <asp:Button ID="btnAgregar" CssClass="btn btn-success" Text="Agregar Producto" runat="server" OnClick="btnAgregar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>


</asp:Content>
