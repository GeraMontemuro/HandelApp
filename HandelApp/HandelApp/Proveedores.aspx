<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="HandelApp.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> PROVEEDORES </h1>

    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">Nuevo Proveedor</button>

    <asp:GridView ID="dgvProveedores" runat="server" CssClass="table" AutoGenerateColumns="false" AutoGenerateColums="false" OnRowCommand="dgvProveedores_RowCommand" >

        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IDProveedor" />
            <asp:BoundField HeaderText="Nombre Fantasia" DataField="NombreFantasia" />
            <asp:BoundField HeaderText="Cuil" DataField="Cuil" />
            <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
            <asp:BoundField HeaderText="Mail" DataField="Mail" />           
           
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IDProveedor") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                     <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IDProveedor") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/pencil.jpg" AlternateText=" "  />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Agregar Proveedor</h1>
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
                    <asp:Button ID="btnAgregarProd" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarProd_Click" />
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </div>
  




</asp:Content>
