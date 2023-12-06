<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaCompra.aspx.cs" Inherits="HandelApp.NuevaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <h1 class="display-2 custom-heading">NUEVA COMPRA </h1>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div style="margin-bottom: 10px;">
                <asp:ImageButton ID="ImagenCalendario" Height="53px" Width="53px" runat="server" ImageUrl="Logos/pngwing.com.png" ImageAlign="AbsBottom" OnClick="ImagenCalendario_Click" />
                <asp:Calendar ID="Calendario1" runat="server" Height="263px" Width="283px" BackColor="#9ec5fe" OnSelectionChanged="Calendario1_SelectionChanged" OnDayRender="Calendario1_DayRender"></asp:Calendar>
                <asp:Label runat="server" Text="Fecha" />
                <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control txtBox" />
                <asp:CompareValidator runat="server" ControlToValidate="txtFecha" Operator="DataTypeCheck" Type="Date"
                    ErrorMessage="La fecha seleccionada no es válida." Text="*" Display="Dynamic" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Producto" />
        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" Width="500px" AutoPostBack="false"></asp:DropDownList>
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Cantidad" />
        <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control txtBox" />
        <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCantidad"
            ErrorMessage="La cantidad debe ser un número entero, mayor a cero"
            Display="Dynamic"
            ValidationExpression="^\d+$"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Precio de Compra" />
        <asp:TextBox runat="server" ID="txtPrecioCompra" CssClass="form-control txtBox" />
        <asp:RangeValidator runat="server" ControlToValidate="txtPrecioCompra"
            ErrorMessage="El precio de compra debe ser númerico y mayor a cero"
            Display="Dynamic"
            MinimumValue="0"
            Type="Double"
            ForeColor="Red" />
    </div>

    <div style="margin-bottom: 10px;">
        <asp:Label runat="server" Text="Proveedor" />
        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" Width="500px" AutoPostBack="false"></asp:DropDownList>
    </div>

    <div>
        <asp:Button ID="btnAgregarCompra" CssClass="btn btn-success" Text="Guardar Compra" runat="server" OnClick="btnAgregarCompra_Click" />
    </div>
    <br />
    <div>        
        <asp:Button ID="btnAgregarProveedor" CssClass="btn btn-dark" Text="Nuevo Proveedor" runat="server" OnClick="btnAgregarProveedor_Click" />
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
