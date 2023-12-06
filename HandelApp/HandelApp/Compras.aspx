<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="HandelApp.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este registro de compra?');
        }
    </script>

    <h1 class="display-2 custom-heading"> COMPRAS </h1>
    <hr />

    <asp:Button type="button" Text="Nueva Compra" CssClass="btn btn-primary" runat="server" ID="btnNvaCompra" OnClick="btnNvaCompra_Click" />
    <asp:GridView ID="dgvCompras" runat="server" CssClass="table" DataKeyNames="IDCompra" AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="IDCompra" DataField="IDCompra" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
            <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Precio Compra" DataField="PrecioCompra" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.NombreFantasia" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <%--<asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IDCompra") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>--%>

                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IDCompra") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/lapizz.jpg" AlternateText=" "  />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>   
</asp:Content>
