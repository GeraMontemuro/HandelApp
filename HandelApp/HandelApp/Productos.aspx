<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="HandelApp.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este producto?');
        }

        function prodAgregado() {
            return confirm('Producto agregado con éxito!');
        }
    </script>

    <h1>PRODUCTOS  </h1>

    <div class="form-floating mb-3">
        
        <asp:TextBox ID="TxtBuscador" runat="server" />
        <asp:Button ID="buscarproducto" class="btn btn-primary" Text="Buscar Producto/s" runat="server" OnClick="buscarproducto_Click" />
       
    </div>

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalNvoProd">Nuevo Producto</button>


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
            <asp:BoundField HeaderText="Precio Venta" DataField="PrecioVenta" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Precio Compra" DataField="PrecioCompra" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton runat="server" Text="Agregar Producto" CommandName="AgregarProd" CommandArgument='<%#Eval("IdProducto") %>' OnClientClick="return prodAgregado();">                    
                    </asp:LinkButton>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IdProducto") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IdProducto") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/pencil.jpg" AlternateText=" "  />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <%--MODAL PRODUCTO NUEVO--%>
    <div class="modal fade" id="modalNvoProd" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="lblNvoProd" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="lblNvoProd">Agregar Producto</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Nombre" />
                        <asp:TextBox runat="server" ID="txtNombre" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Descripción" />
                        <asp:TextBox runat="server" ID="txtDescripcion" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Código" />
                        <asp:TextBox runat="server" ID="txtCodigo" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Marca" />
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Categoria" />
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Stock Total" />
                        <asp:TextBox runat="server" ID="txtStockTotal" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Stock Mínimo" />
                        <asp:TextBox runat="server" ID="txtStockMinimo" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Precio de Compra" />
                        <asp:TextBox runat="server" ID="txtPrecio" />
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregarProd" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarProd_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </div>



</asp:Content>
