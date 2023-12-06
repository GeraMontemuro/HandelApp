<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoProveedor.aspx.cs" Inherits="HandelApp.NuevoProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>NUEVO PROVEEDOR </h1>

    <div style="margin-bottom: 10px;">
     <asp:Label runat="server" Text="Nombre" />
     <asp:TextBox runat="server" ID="txtNombre" />
     <asp:RegularExpressionValidator runat="server" ControlToValidate="txtNombre"
         ErrorMessage="Se requiere un nombre"
         Display="Dynamic"
         ValidationExpression="^.{3,50}$"
         ForeColor="Red" />
 </div>

 <div style="margin-bottom: 10px;">
     <asp:Label runat="server" Text="Cuil" />
     <asp:TextBox runat="server" ID="txtCuil" />
     <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCuil"
         ErrorMessage="Se requiere un cuil"
         Display="Dynamic"
         ValidationExpression="^.{3,10}$"
         ForeColor="Red" />
 </div>

 <div style="margin-bottom: 10px;">
     <asp:Label runat="server" Text="Telefono" />
     <asp:TextBox runat="server" ID="txtTelefono" />
     <asp:RegularExpressionValidator runat="server" ControlToValidate="txtTelefono"
         ErrorMessage="telefono incorrecto"
         Display="Dynamic"
         ValidationExpression="^.{3,50}$"
         ForeColor="Red" />
 </div>

 <div style="margin-bottom: 10px;">
     <asp:Label runat="server" Text="Mail" />
     <asp:TextBox runat="server" ID="txtMail" />
     <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMail"
         ErrorMessage="email incorrecto"
         Display="Dynamic"
         ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
         ForeColor="Red" />
 </div>

    <div class="modal-footer">
        <asp:Button ID="btnAgregarProv" CssClass="btn btn-success" Text="Agregar" runat="server" Onclick="btnAgregarProv_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-success" Text="Cancelar" runat="server" Onclick="btnCancelar_Click"  />
    </div>


</asp:Content>
