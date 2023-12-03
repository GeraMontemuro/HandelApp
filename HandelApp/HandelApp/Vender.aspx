<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>CARGAR VENTA </h1>

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

                <asp:GridView ID="dgvClienteVenta" runat="server" Width="100%">
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
    <div class="card">
        <div class="card-body">
            <h1>PRODUCTO </h1>

            <asp:TextBox ID="txtBusquedaProducto" runat="server" CssClass="form-control" placeholder="Buscar producto..." AutoPostBack="false"></asp:TextBox>
            <asp:Button ID="btnBusquedaProducto" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnBusquedaProducto_Click" />
            <br />

            <%--<asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" AutoPostBack="true" >
                    <asp:ListItem Text="Seleccionar Cliente" Value=""  />
                </asp:DropDownList>--%>
            <br />

            <asp:GridView ID="dgvProdBuscado" runat="server" OnRowCommand="dgvProdBuscado_RowCommand">

                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="IDProducto" />
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Producto" DataField="MarcaYNombre" />


                    <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="SeleccionarProd" />

                </Columns>


            </asp:GridView>
            <asp:GridView ID="dgvProductoVenta" runat="server" Width="100%">

                <Columns>
                    <asp:BoundField HeaderText="Nombre Producto" DataField="Nombre" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="Precio" />
                </Columns>


            </asp:GridView>
        </div>
    </div>
</asp:Content>
