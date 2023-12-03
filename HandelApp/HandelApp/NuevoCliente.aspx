<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="HandelApp.NuevoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>NUEVO CLIENTE </h1>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Nombre" />
        <asp:TextBox runat="server" ID="txtNombre" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Cuil" />
        <asp:TextBox runat="server" ID="txtCuil" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Telefono" />
        <asp:TextBox runat="server" ID="txtTelefono" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Mail" />
        <asp:TextBox runat="server" ID="txtMail" />
    </div>


    <div class="modal-footer">
        <asp:Button ID="btnAgregarCliente" CssClass="btn btn-success" Text="Agregar" runat="server" Onclick="btnAgregarCliente_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-success" Text="Cancelar" runat="server" OnClick="btnCancelar_Click"    />
    </div>
</asp:Content>
