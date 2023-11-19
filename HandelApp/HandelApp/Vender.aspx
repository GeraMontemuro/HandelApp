<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <%--<h1 class="display-2 custom-heading"">Nueva Venta   </h1>  --%>

<div class="form-floating mb-3">
    <asp:Label runat="server" Text="Cliente" />
    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control" placeholder="Selecciona el cliente" AutoPostBack="true"></asp:DropDownList>

</div>

<asp:GridView ID="dgvVentas" runat="server" CssClass="table" DataKeyNames="IDProducto" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged">
    <Columns>

        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        <asp:BoundField HeaderText="PrecioVenta" DataField="PrecioCompra" DataFormatString="{0:C}" />
        <asp:CommandField ShowSelectButton="true" SelectText="Eliminar Producto" HeaderText="Acción" />

        <asp:TemplateField HeaderText="Stock a Vender">
            <ItemTemplate>

                <asp:LinkButton ID="lnkbtnRestar" runat="server" CommandName="Restar" CommandArgument='<%#Eval("IdProducto") %>'>              
                <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/pngwing.com%20(menos).png" AlternateText="Eliminar" />
                </asp:LinkButton>

                <asp:TextBox ID="txtStockavender" runat="server" CssClass="maspequeña" />  

                <asp:LinkButton ID="lnkbtnSumar" runat="server" CommandName="Sumar" CommandArgument='<%#Eval("IdProducto") %>'>
                <asp:Image runat="server" class="maspequeña"  src="Logos/pngwing.com%20(mas).png" AlternateText=" "  />
                </asp:LinkButton>

            </ItemTemplate>
        </asp:TemplateField>


    </Columns>


</asp:GridView>

<asp:Label ID="lblPrecio" Style="color: brown" runat="server" Text="Precio Total: "></asp:Label>
<asp:TextBox ID="TextPrecioTotal" ReadOnly="true" CssClass="form-control" runat="server" Style="width: 150px; height: 45px" alt="..."></asp:TextBox>
<asp:Button runat="server" Text="Imprimir Factura" OnClick="BtnFactura_Click" />

</asp:Content>
