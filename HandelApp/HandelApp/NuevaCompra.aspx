<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaCompra.aspx.cs" Inherits="HandelApp.NuevaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server"></asp:ScriptManager>  
    <asp:UpdatePanel runat="server">
        <contenttemplate>

            <div style="margin-bottom: 10px;">
                <asp:ImageButton ID="ImagenCalendario" Height="53px" Width="53px" runat="server" ImageUrl="Logos/pngwing.com.png" ImageAlign="AbsBottom" OnClick="ImagenCalendario_Click" />
                <asp:Calendar ID="Calendario1" runat="server" Height="263px" Width="283px" BackColor="#9ec5fe" OnSelectionChanged="Calendario1_SelectionChanged" OnDayRender="Calendario1_DayRender"></asp:Calendar>
                <asp:Label runat="server" Text="Fecha" />
                <asp:TextBox runat="server" ID="txtFecha" />

            </div>
        </contenttemplate>
    </asp:UpdatePanel>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Producto" />
        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" AutoPostBack="false"></asp:DropDownList>
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Cantidad" />
        <asp:TextBox runat="server" ID="txtCantidad" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Precio de Compra" />
        <asp:TextBox runat="server" ID="txtPrecioCompra" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Proveedor" />
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" AutoPostBack="false"></asp:DropDownList>
    </div>



    <div class="modal-footer">
        <asp:Button ID="btnAgregarCompra" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarCompra_Click" />
        <asp:Button ID="btnAgregarCliente" CssClass="btn btn-success" Text="+ Cliente" runat="server" Onclick="btnAgregarCliente_Click" />
        <asp:Button ID="btnAgregarProveedor" CssClass="btn btn-success" Text="+ Proveedor" runat="server" Onclick="btnAgregarProveedor_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>









</asp:Content>
