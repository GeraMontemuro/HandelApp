<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarPerfilUsuario.aspx.cs" Inherits="HandelApp.EditarPerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label for="Usuario">Usuario</label>
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="contraseña">Contraseña</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
            </div>

            <div class="mb-3">
                <label for="Nombre">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="Apellido">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="Mail">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="Fecha">Fecha Nacimiento</label>
                <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label class="form-class">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
                <%-- </div>
                <asp:Image ID="imaNuevoPerfil" ImageUrl="~/Logos/Logo.jpg" runat="server" CssClass="img-fluid mb-3" />--%>

             </div>
                <asp:Button Text="Guardar" runat="server" ID="btnGuardarEditarPerfil" OnClick="btnGuardarEditarPerfil_Click" />
                <a href="Usuario.aspx">Regresar</> </a>
            </div>
        
        </div>
</asp:Content>
