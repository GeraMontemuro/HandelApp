<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarCliente.aspx.cs" Inherits="HandelApp.EditarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>EDITAR CLIENTE </h1>

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
    <asp:TextBox runat="server" ID="TxtMail" />
</div>


    <div class="modal-footer">
    <asp:Button ID="btnGuardarCambios" CssClass="btn btn-success" Text="Guardar Cambios" runat="server" OnClick="btnGuardarCambios_Click" />
    <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>


</asp:Content>
