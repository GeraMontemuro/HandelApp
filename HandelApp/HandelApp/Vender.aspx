<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vender.aspx.cs" Inherits="HandelApp.Vender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1 class="display-2 custom-heading"">VENTAS   </h1>       
    
    <asp:GridView ID="dgvVentas" runat="server" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="ID" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
        </Columns>
        </asp:GridView>

</asp:Content>
