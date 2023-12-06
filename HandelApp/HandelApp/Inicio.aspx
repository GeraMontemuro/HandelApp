<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HandelApp.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <h1 class="display-2 custom-heading"> HANDELAPP </h1>
    
    <br />

    <div class="container">
    <div class="row align-items-start">
        <div class="col">
            <asp:LinkButton runat="server" ID="btnNuevaVenta" OnClick="btnNuevaVenta_Click" style="display: inline-block; width: 250px; height: 250px; padding: 0; margin: 0; background-color: black; border: none; cursor: pointer; border-radius: 10px; box-shadow: 3px 3px 5px #888888; outline: none;">
                <img src="Logos/NuevaVenta.png" alt="..." style="width: 100%;" />
            </asp:LinkButton>
        </div>
        <div class="col">
            <asp:LinkButton runat="server" ID="btnNuevaCompra" OnClick="btnNuevaCompra_Click" style="display: inline-block; width: 250px; height: 250px; padding: 0; margin: 0; background-color: black; border: none; cursor: pointer; border-radius: 10px; box-shadow: 3px 3px 5px #888888; outline: none;">
                <img src="Logos/NuevaCompra.png" alt="..." style="width: 100%;" />
            </asp:LinkButton>
        </div>
        <div class="col">
            <asp:LinkButton runat="server" ID="btnFacturas" OnClick="btnFacturas_Click" style="display: inline-block; width: 250px; height: 250px; padding: 0; margin: 0; background-color: black; border: none; cursor: pointer; border-radius: 10px; box-shadow: 3px 3px 5px #888888; outline: none;">
                <img src="Logos/Facturas.png" alt="..." style="width: 100%;" />
            </asp:LinkButton>
        </div>
    </div>
</div>

</asp:Content>
