<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="HandelApp.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>PRODUCTOS  </h1>

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
       +
    </button>


    <asp:GridView ID="dgvProductos" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" DataKeyNames="IDProducto">

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
                <asp:LinkButton runat="server" CommandName="Edit">
                    <asp:Image runat="server" class="pequeña"  src="Logos/pencil.jpg" AlternateText=" "  />
                </asp:LinkButton>
                <asp:LinkButton runat="server" CommandName="Edit">
                    <asp:Image runat="server" AlternateText="tacho" /> </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    </asp:GridView>
    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar Producto</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    
                </div>
                <div class="modal-body">
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Producto" />
                        <asp:TextBox runat="server" ID="txtProducto" />
                    </div>
                    
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Nombre" />
                        <asp:TextBox runat="server" ID="txtNombre" />
                    </div>
                    
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Descripción" />
                        <asp:TextBox runat="server" ID="txtDescripcion" />
                    </div>
                    
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Precio" />
                        <asp:TextBox runat="server" ID="txtPrecio" />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-primary" onclick="btn_cargarProducto">Cargar Producto</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
