<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevaFactura.aspx.cs" Inherits="HandelApp.NuevaFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-body">
            <div class="row g-3">
                <div class="card">
                    <div class="card-body">
                        <div class="col-md-8">
                            <div class="left">
                                <img src="Logos/Logo.jpg" alt="Logo" />
                            </div>
                        </div>

                        <div class="col-md-6">
                            <asp:Label ID="lblVendedor" runat="server" CssClass="form-label" Text="Vendedor"></asp:Label>
                            <asp:TextBox ID="txtVendedor" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblNroFactura" runat="server" CssClass="form-label" Text="Número de Factura"></asp:Label>
                            <asp:TextBox ID="txtNroFactura" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                </div>

                <div class="card">
                    <div class="card-body">
                        <div class="col-12">
                            <asp:Label ID="lblCliente" runat="server" CssClass="form-label" Text="Cliente"></asp:Label>
                            <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-12">
                            <asp:Label ID="lblMail" runat="server" CssClass="form-label" Text="Mail"></asp:Label>
                            <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblCuit" runat="server" CssClass="form-label" Text="CUIT/CUIL"></asp:Label>
                            <asp:TextBox ID="txtCuil" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <asp:Label ID="lblTelefono" runat="server" CssClass="form-label" Text="Teléfono"></asp:Label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>

                </div>

            </div>
            <div class="card">
                <div class="card-body">
                    <h1>PRODUCTOS </h1>
                    <asp:GridView ID="dgvProdFactura" CssClass="table" AutoGenerateColumns="false" runat="server" Width="100%">

                        <Columns>
                            <asp:BoundField HeaderText="Nombre Producto" DataField="Nombre" />
                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                            <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioVenta" DataFormatString="{0:C}" />
                            <asp:BoundField HeaderText="Precio Final" DataField="PrecioFinal" DataFormatString="{0:C}" />


                        </Columns>

                    </asp:GridView>
                </div>
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblTotal" runat="server" CssClass="form-label" Text="TOTAL:"></asp:Label>

            </div>
            <div class="col-md-2">

                <asp:TextBox ID="txtTotalFactura" ReadOnly="true" CssClass="form-control" runat="server" Style="width: 150px; height: 45px" alt="..."></asp:TextBox>
            </div>

            <div class="col-12">
                <asp:Button ID="btnImprimir" runat="server" CssClass="btn btn-primary" Text="Imprimir" />
            </div>
        </div>
    </div>
</asp:Content>
