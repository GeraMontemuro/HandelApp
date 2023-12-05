<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandelApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <div class="container">
        <div class="left">
            <img src="Logos/Logo.jpg" alt="Logo" />
        </div>

        <div class="right">
            <div class="login-box">
                <h2>Iniciar sesión</h2>

                <form runat="server">
                    <div class="input-container">
                        <label for="usuario">Usuario</label>
                         <asp:TextBox runat ="server" ID="txtUsuario"  CssClass="form-control" />
                    
                    </div>

                    <div class="input-container" type="password">
                        <label for="contraseña">Contraseña</label>
                         <asp:TextBox runat ="server" ID="txtPassword" textmode="Password" CssClass="form-control" />
                    
                    </div>

                        
                    <asp:Button Text="Iniciar sesión" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click"/>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
