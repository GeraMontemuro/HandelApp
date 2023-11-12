<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="HandelApp.WebForm1" %>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Factura</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .factura {
            max-width: 600px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
        }

        .encabezado {
            text-align: center;
            margin-bottom: 20px;
        }

        .detalles {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }

        .detalles th, .detalles td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .total {
            text-align: right;
        }
    </style>
</head>
<body>

    <div class="factura">  <%--modelo de factura--%>
        <div class="encabezado">
            <h2>Factura</h2>
            <p>Fecha: 10 de noviembre de 2023</p>
        </div>

        <table class="detalles">
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Cantidad</th>
                    <th>Precio Unitario</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Producto 1</td>
                    <td>2</td>
                    <td>$10.00</td>
                    <td>$20.00</td>
                </tr>
                <tr>
                    <td>Producto 2</td>
                    <td>1</td>
                    <td>$15.00</td>
                    <td>$15.00</td>
                </tr>
            </tbody>
        </table>

        <div class="total">
            <p>Total: $35.00</p>
        </div>
    </div>

</body>
</html>
