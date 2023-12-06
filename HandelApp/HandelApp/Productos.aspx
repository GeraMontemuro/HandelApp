<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="HandelApp.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este producto?');
        }

       
    </script>

    <h1 class="display-2 custom-heading"> PRODUCTO </h1>

    <div class="form-floating mb-3">
        
        <asp:TextBox ID="TxtBuscador" runat="server"  />
        <asp:Button ID="buscarproducto" class="btn btn-dark" Text="Buscar Producto/s" runat="server" OnClick="buscarproducto_Click" />
       
    </div>

    <asp:Button type="button" Text="Agregar Producto" CssClass="btn btn-primary" runat="server" ID="btnAgregProd" OnClick="btnAgregProd_Click" />


    <asp:GridView ID="dgvProductos" runat="server" CssClass="table" DataKeyNames="IDProducto" AutoGenerateColumns="false" OnRowCommand="dgvProductos_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IDProducto" />
            <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Stock Total" DataField="StockTotal" />
            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
            <asp:BoundField HeaderText="Porcentaje Ganancia" DataField="PorcentajeGAnancia" DataFormatString="{0}%" />
            <asp:BoundField HeaderText="Precio Compra" DataField="PrecioCompra" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>                    
                    <div class="d-flex justify-content-around">
                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IdProducto") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IdProducto") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/lapizz.jpg" AlternateText=" "  />
                    </asp:LinkButton>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView> 

    </asp:Content>
