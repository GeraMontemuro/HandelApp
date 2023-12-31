﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarProducto.aspx.cs" Inherits="HandelApp.EditarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="display-2 custom-heading">EDITAR PRODUCTO </h1>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Nombre" />
        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNombre"
            ErrorMessage="La longitud del nombre debe estar entre 3 y 50 caracteres"
            Display="Dynamic"
            ValidationExpression="^.{3,50}$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Descripción" />
        <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtDescripcion"
            ErrorMessage="La longitud de la descripción debe estar entre 3 y 50 caracteres"
            Display="Dynamic"
            ValidationExpression="^.{3,50}$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Código" />
        <asp:TextBox runat="server" ID="txtCodigo" ReadOnly="true" BackColor="Silver" CssClass="form-control txtBox" />

    </div>


    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Marca" />
        <asp:TextBox runat="server" ID="txtMarca" ReadOnly="true" BackColor="Silver" CssClass="form-control txtBox" />

    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Categoria" />
        <asp:TextBox runat="server" ID="txtCategoria" ReadOnly="true" BackColor="Silver" CssClass="form-control txtBox" />

    </div>


    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Stock Total" />
        <asp:TextBox runat="server" ID="txtStockTotal" ReadOnly="true" BackColor="Silver" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtStockTotal"
            ErrorMessage="Stock Total debe ser un número entero"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Stock Mínimo" />
        <asp:TextBox runat="server" ID="txtStockMinimo" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtStockMinimo"
            ErrorMessage="Stock Mínimo debe ser un número entero"
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
        <asp:Label runat="server" Text="Porcentaje de Ganancia" />
        <asp:TextBox runat="server" ID="txtPorcentaje" CssClass="form-control txtBox" />
        <asp:RangeValidator runat="server" ControlToValidate="txtPorcentaje"
            ErrorMessage="El  porcentaje de ganancia debe estar entre 0 y 100"
            Display="Dynamic"
            MinimumValue="0"
            MaximumValue="100"
            Type="Integer"
            ForeColor="Red" />
    </div>

    <div>
        <asp:Button ID="btnGuardarCambios" CssClass="btn btn-success" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambios_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
