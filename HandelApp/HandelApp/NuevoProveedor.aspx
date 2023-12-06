<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoProveedor.aspx.cs" Inherits="HandelApp.NuevoProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function proveedorAgregado() {
            return confirm('Proveedor agregado con éxito!');
        }

    </script>

    <h1 class="display-2 custom-heading"> NUEVO PROVEEDOR </h1>

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
        <asp:Label runat="server" Text="Cuil" />
        <asp:TextBox runat="server" ID="txtCuil" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCuil"
            ErrorMessage="Se requiere un CUIL/CUIT"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Telefono" />
        <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtTelefono"
            ErrorMessage="Indicar código de área"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Mail" />
        <asp:TextBox runat="server" ID="txtMail" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtMail"
            ErrorMessage="La dirección de correo electrónico no es válida"
            Display="Dynamic"
            ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
            ForeColor="Red" />
    </div>

    <div>
        <asp:Button ID="btnAgregarProv" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarProv_Click" OnClientClick="return proveedorAgregado();" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
    </div>


</asp:Content>
