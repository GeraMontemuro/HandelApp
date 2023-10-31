<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandelApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <link rel="stylesheet" href="Styles.css" />
      
           <div class ="formulario1">
                <h1> INICIO DE SESION </h1>
               <div class="username">
                   <input type="text" required />
                   <label>Nombre de Usuario</label>
               </div>
               <div class="username">
                   <input type="password" required />
                   <label>Contraseña</label>
               </div>
               <div class="recordar">Olvido su contraseña?</div>
               <input type="submit" value="Iniciar" />
               <div class ="registrase">
                   Quiero hacer el <a href="#">Registro</a>
               </div>

           </div>




    <hr />
</asp:Content>
