<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="HandelApp.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server"></asp:ScriptManager>   
   <script type="text/javascript">
        function confirmarEliminar() {
            return confirm('¿Estás seguro de que deseas eliminar este registro de compra?');
        }
   </script>
     <h1> COMPRAS </h1>

     <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#modalNvaCompra">Cargar Compra</button>

    <asp:GridView ID="dgvCompras" runat="server" CssClass="table" DataKeyNames="IDCompra"  AutoGenerateColumns="false" OnRowCommand="dgvCompras_RowCommand" >
       
        <Columns>
            <asp:BoundField HeaderText="IDCompra" DataField="IDCompra" />
            <asp:BoundField HeaderText="Fecha" DataField="Fecha" />            
            <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />   
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />             
            <asp:BoundField HeaderText="Precio Compra" DataField="PrecioCompra" DataFormatString="{0:C}" />
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.NombreFantasia" /> 
           
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>

                    <asp:LinkButton ID="lnkbtnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%#Eval("IDCompra") %>' OnClientClick="return confirmarEliminar();">              
                    <asp:Image runat="server" CssClass="maspequeña" ImageUrl="Logos/trash.jpg" AlternateText="Eliminar" />
                    </asp:LinkButton>

                     <asp:LinkButton runat="server" CommandName="Editar" CommandArgument='<%#Eval("IDCompra") %>'>
                    <asp:Image runat="server" class="maspequeña"  src="Logos/pencil.jpg" AlternateText=" "  />
                    </asp:LinkButton>

                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <%--MODAL NUEVA COMPRA --%>
    <div class="modal fade" id="modalNvaCompra" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="lblNvaCompra" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="lblNvaCompra">Cargar Compra</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>

                <div class="modal-body">

                   
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <div style="margin-bottom: 10px;">
                                <asp:ImageButton ID="ImagenCalendario" Height="53px" Width="53px" runat="server" ImageUrl="Logos/pngwing.com.png"  ImageAlign="AbsBottom" OnClick="ImagenCalendario_Click"  />
                                <asp:Calendar ID="Calendario1" runat="server" Height="263px" Width="283px" BackColor="#9ec5fe"  OnSelectionChanged="Calendario1_SelectionChanged"  OnDayRender="Calendario1_DayRender"  ></asp:Calendar>
                                <asp:Label runat="server" Text="Fecha" /> 
                                <asp:TextBox runat="server" ID="txtFecha" />

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  
                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Producto" />
                        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-select" AutoPostBack="false"></asp:DropDownList>
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Cantidad" />
                        <asp:TextBox runat="server" ID="txtCantidad" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Precio de Compra" />
                        <asp:TextBox runat="server" ID="txtPrecioCompra" />
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Label runat="server" Text="Proveedor" />
                        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-select" AutoPostBack="false"></asp:DropDownList>
                    </div>


                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAgregarCompra" CssClass="btn btn-success" Text="Agregar" runat="server" OnClick="btnAgregarCompra_Click"/>
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>

            </div>
        </div>
    </div>
  
</asp:Content>
