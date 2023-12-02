<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="HandelApp.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>USUARIOS</h1>


    <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Usuario" DataField="User" />
            <asp:BoundField HeaderText="TipoUsuario" DataField="TipoUsuario" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Mail" />
            <asp:BoundField HeaderText="FechaNacimiento" DataField="FechaNacimiento" />

        </Columns>

    </asp:GridView>

</asp:Content>
