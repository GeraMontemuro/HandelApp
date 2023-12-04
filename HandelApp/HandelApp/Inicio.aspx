<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HandelApp.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <h1>HANDELAPP</h1>

    <div class="container text-center">
        <div class="row align-items-start">
            <div class="col">
                <button class="btnAcciones">
                    <img src="Logos/CARGAR%20STOCK.png"  heigth="100px" alt="...">
                </button>
            </div>
            <div class="col">
                <button class="btnAcciones">
                    <img src="Logos/REGISTRAR%20VENTA.png" alt="...">
                </button>
            </div>
            <div class="col">
                <button class="btnAcciones">
                    <img src="Logos/FACTURAS%20EMITIDAS.png" alt="...">
                </button>
            </div>
        </div>
    </div>
</asp:Content>
