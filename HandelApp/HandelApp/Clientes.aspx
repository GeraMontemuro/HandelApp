<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="HandelApp.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar el cliente?');
        }
    </script>

    <h1 class="display-2 custom-heading"> CLIENTES </h1>
    <div class="form-floating mb-3">

        <asp:TextBox ID="TxtBuscador" runat="server" />
        <asp:Button ID="buscarcliente" class="btn btn-dark" Text="Buscar Cliente/s" runat="server" OnClick="buscarcliente_Click" />

    </div>

    <asp:Button type="button" Text="Agregar Cliente" CssClass="btn btn-primary" runat="server" ID="btnAgregClie" Onclick="btnAgregClie_Click"    />

    <asp:GridView ID="dgvClientes" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" DataKeyNames="IdCliente" OnRowCommand="dgvClientes_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IdCliente" />
            <asp:BoundField HeaderText="Nombre Cliente" DataField="NombreFantasia" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
            <asp:BoundField HeaderText="Contacto" DataField="Mail" />


            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IdCliente") %>' OnClientClick="return confirmarEliminar();">
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IdCliente") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/lapizz.jpg" AlternateText=" "  />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
