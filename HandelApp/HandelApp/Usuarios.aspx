<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="HandelApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>USUARIOS</h1>

     
    <div class="row"> 
        <div class="col-md-4">
            <div class="mb-3">

               

                <label for="Usuario">Usuario</label>
                <asp:TextBox runat ="server" ID="txtUsuario"  CssClass="form-control" />
      
             <div class="mb-3">
                 <label for="Nombre">Nombre</label>
                 <asp:TextBox runat ="server" ID="txtNombre"  CssClass="form-control" />
    
            </div>

            <div class="mb-3">
             <label for="Apellido">Apellido</label>
             <asp:TextBox runat ="server" ID="txtApellido"  CssClass="form-control" />
  
            </div>
             <divc lass="mb-3">
                 <label for="Mail">Email</label>
                 <asp:TextBox runat ="server" ID="txtEmail"  CssClass="form-control" />
               
            </div>
             <div class="mb-3">
                <label for="Fecha">Fecha</label>
                <asp:TextBox runat ="server" ID="txtFecha"  CssClass="form-control" />
  
            </div>
        </div>
        <div class="col-mb-4"> 

                <div class="mb-3">
                    <label class="form-class">Imagen Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imaNuevoPerfil" ImageUrl="~/Logos/Logo.jpg" runat="server" CssClass="img-fluid mb-3" />

            </div>
    </div>
    <div class="row">

    <div class="col-mb-4">
     <asp:Button Text="Guardar" runat="server" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" />
     <a  href="Inicio.aspx">Regresar</></a>
       <%if (((dominio.Usuario)Session["usuario"])!= null &&((dominio.Usuario)Session["usuario"]).TipoUsuario== dominio.TipoUsuario.ADMIN) { %>
     <asp:Button Text ="Agregar Nuevo Usuario" runat="server" CssClass="btn btn-primary" ID="btnNuevoUsuario" onclick="btnNuevoUsuario_Click1" />
           <% }; %>
    </div>
    </div>


</asp:Content>
