<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandelApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles.css" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
</head>
<body class="d-flex align-items-center justify-content-center" style="background-color: black">

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
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                    </div>

                    <div class="input-container">
                        <label for="contraseña">Contraseña</label>
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" />
                    </div>

                    <asp:Button Text="Iniciar sesión" runat="server" ID="btnIngresar" OnClick="btnIngresar_Click" />
                    <asp:Label ID="Verificacion" runat="server" Text="" ForeColor="Red"></asp:Label>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
