<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="HandelApp.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>CLIENTES   </h1>

    <asp:GridView ID="dgvClientes" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" DataKeyNames="IdCliente">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IdCliente" />
            <asp:BoundField HeaderText="Nombre Cliente" DataField="NombreFantasia" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Contacto" DataField="Mail" />
        </Columns>
    </asp:GridView>

</asp:Content>
