<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewLogin.aspx.cs" Inherits="HandelApp.NewLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="row"> 
    <div class="col-md-4">
        <div class="mb-3">
            <label for="Usuario">Usuario</label>
            <asp:TextBox runat ="server" ID="txtUsuario"  CssClass="form-control" />
  
         <div class="mb-3">
              <label for="contraseña">Contraseña</label>
                <asp:TextBox runat ="server" ID="txtPassword"  CssClass="form-control" textmode="Password"/>
             <label for="Nombre">Nombre</label>
             <asp:TextBox runat ="server" ID="txtNombre"  CssClass="form-control" />

        </div>
</div>
    </div>
                <asp:Button Text="Guardar" runat="server" ID="GuardarEditarPerfil" OnClick="GuardarEditarPerfil_Click" CssClass="btn btn-primary" Font-Size="Small"/>
            </div>

</asp:Content>
