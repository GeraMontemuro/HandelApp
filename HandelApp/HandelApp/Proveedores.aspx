<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="HandelApp.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este producto?');
        }

    </script>
    <h1>PROVEEDORES </h1>

    <div class="form-floating mb-3">

        <asp:TextBox ID="TxtBuscador" runat="server" />
        <asp:Button ID="buscarproveedor" class="btn btn-dark" Text="Buscar Proveedor/es" runat="server" OnClick="buscarproveedor_Click" />

    </div>


    <asp:Button type="button" Text="Agregar Proveedor" CssClass="btn btn-primary" runat="server" ID="btnAgregProv" OnClick="btnAgregProv_Click" />

    <asp:GridView ID="dgvProveedores" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" OnRowCommand="dgvProveedores_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IDProveedor" />
            <asp:BoundField HeaderText="Nombre Fantasia" DataField="NombreFantasia" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Mail" DataField="Mail" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IDProveedor") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IDProveedor") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/lapizz.jpg" AlternateText=" "  />
                    </asp:LinkButton>


                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
</asp:Content>
