<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este producto?');
        }
    </script>

    <h1>CARGAR VENTA </h1>

    <div class="container text-center">
        <div class="row align-items-start">
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <h1>CLIENTE </h1>

                        <div>

                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" placeholder="Buscar Cliente..." AutoPostBack="true" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />
                            <div>

                                <asp:Label runat="server" Text="Búsqueda por CUIT/CUIL:" />
                                <asp:TextBox ID="txtBuscarCuit" runat="server" />
                                <asp:Button ID="btnBuscarCuit" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBuscarCuit_Click" />

                            </div>

                            <asp:GridView ID="dgvClienteVenta" CssClass="table" AutoGenerateColumns="false" runat="server" Width="100%">
                                <Columns>

                                    <asp:BoundField HeaderText="Nombre Cliente" DataField="NombreFantasia" />
                                    <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
                                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                                    <asp:BoundField HeaderText="Mail" DataField="Mail" />

                                </Columns>
                            </asp:GridView>
                            <hr />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col">
                <div class="card">
                    <div class="card">
                        <div class="card-body">
                            <h1>PRODUCTO </h1>

                            <asp:DropDownList ID="ddlProducto" runat="server"  CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
                                <asp:ListItem Text="Seleccionar Producto" Value="" />
                            </asp:DropDownList>
                            <br />

                            <asp:TextBox ID="txtBusquedaProducto" runat="server" CssClass="form-control" placeholder="Buscar producto..." AutoPostBack="false"></asp:TextBox>
                            <asp:Button ID="btnBusquedaProducto" runat="server" Text="Buscar por Nombre" CssClass="btn btn-success" OnClick="btnBusquedaProducto_Click" />
                            <asp:Button ID="btnLimpiarFiltros" runat="server" text="Limpiar Filtro" CssClass="btn btn-success" OnClick="btnLimpiarFiltros_Click"/>   


                            <asp:GridView ID="dgvProdBuscado" runat="server" CssClass="table" AutoGenerateColumns="false" OnRowCommand="dgvProdBuscado_RowCommand">

                                <Columns>
                                    <%--<asp:BoundField HeaderText="Id" DataField="IDProducto" />--%>
                                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                    <asp:BoundField HeaderText="Producto" DataField="MarcaYNombre" />
                                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                    <asp:BoundField HeaderText="Stock" DataField="StockTotal" />
                                    <asp:BoundField HeaderText="Precio Unit" DataField="PrecioVenta" DataFormatString="{0:C}" />

                                    <asp:TemplateField HeaderText="Cantidad">
                                        <ItemTemplate>

                                            <asp:TextBox ID="txtCantidad" Style="width: 70px; text-align: center;" MaxLength="7" runat="server" Text='<%#Eval("Cantidad") %>'></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Agregar a Fac">
                                        <ItemTemplate>

                                            <%--<asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="SeleccionarProd" />--%>
                                            <asp:LinkButton ID="lnkbtnAgregarlista" runat="server" CommandName="SeleccionarProd" CommandArgument='<%#Eval("IdProducto") %>'>
                                            <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/pngwing.com(check).png" AlternateText="Agregar"/>
                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblMensajestock" runat="server" CssClass="text-danger"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="card">
        <div class="card-body">
            <h1>PRE-FACTURA </h1>
            <asp:GridView ID="dgvProductoVenta" CssClass="table" AutoGenerateColumns="false" runat="server" Width="100%" OnRowCommand="dgvProductoVenta_RowCommand">

                <Columns>
                    <asp:BoundField HeaderText="Nombre Producto" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioVenta" DataFormatString="{0:C}" />
                    <asp:BoundField HeaderText="Precio Final" DataField="PrecioFinal" DataFormatString="{0:C}" />

                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>


                            <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IdProducto") %>' OnClientClick="return confirmarEliminar();">              
                            <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                            </asp:LinkButton>


                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
    <asp:Label ID="lblPrecio" Style="color: brown" runat="server" Text="Precio Total: "></asp:Label>
    <asp:TextBox ID="TxtPrecioTotal" ReadOnly="true" CssClass="form-control" runat="server" Style="width: 150px; height: 45px" alt="..."></asp:TextBox>
    <asp:Button ID="btnAgregarFactura" runat="server" CssClass="btn btn-success" Text="Imprimir Factura" Onclick="btnAgregarFactura_Click"     />
</asp:Content>
