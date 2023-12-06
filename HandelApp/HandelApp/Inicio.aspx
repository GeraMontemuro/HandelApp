<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HandelApp.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>HANDELAPP</h1>

    <div class="container text-center">
        <div class="row align-items-start">
            <div class="col">
                
                <button class="btnAcciones" runat="server"  >
                    <img src= "Logos/NuevaVenta.png" />  alt="..."></button>
            </div>
            <div class="col">
                <button class="btnAcciones">
                    <img src= "Logos/NuevaCompra.png"  /> alt="..."></button>
            </div>
            <div class="col">
                <button class="btnAcciones">
                    <img src= "Logos/Facturas.png" /> alt="..."></button>
            </div>
        </div>
    </div>
</asp:Content>
