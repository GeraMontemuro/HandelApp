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
                <form method="post" action="Inicio.aspx">
                    <div class="input-container">
                        <label for="usuario">Usuario</label>
                        <input type="text" id="usuario" name="usuario" required/>
                    </div>
                    <div class="input-container">
                        <label for="contraseña">Contraseña</label>
                        <input type="password" id="contraseña" name="contraseña" required/>
                    </div>
                        <input type="submit" value="Iniciar sesión"/>                  
                </form>
            </div>
        </div>
    </div>
</body>
</html>
