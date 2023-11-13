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
    <h1>CLIENTES   </h1>

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">Nuevo Cliente</button>

    <asp:GridView ID="dgvClientes" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" DataKeyNames="IdCliente" OnRowCommand="dgvClientes_RowCommand">

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IdCliente" />
            <asp:BoundField HeaderText="Nombre Cliente" DataField="NombreFantasia" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Contacto" DataField="Mail" />


            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IdCliente") %>' OnClientClick="return confirmarEliminar();">
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar Cliente</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>

                </div>
                <div class="modal-body">

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Nombre" />
                        <asp:TextBox runat="server" ID="txtNombre" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Cuil" />
                        <asp:TextBox runat="server" ID="txtCuil" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Telefono" />
                        <asp:TextBox runat="server" ID="txtTelefono" />
                    </div>
                    
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Mail" />
                        <asp:TextBox runat="server" ID="txtMail" />
                    </div>

                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregarProd" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarCLiente_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
