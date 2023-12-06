using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class NuevaCompra : System.Web.UI.Page
    {
        Compra compra = new Compra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendario1.Visible = false;

                CompraNegocio comNeg = new CompraNegocio();
                List<Compra> lista = new List<Compra>();
                lista = comNeg.listarconSp();

                Producto prodaux = new Producto();
                ProductoNegocio ProdNegAux = new ProductoNegocio();
                List<Producto> listaProducto = new List<Producto>();

                Proveedor proveedoraux = new Proveedor();
                ProveedorNegocio ProvNegAux = new ProveedorNegocio();
                List<Proveedor> listaProveedor = new List<Proveedor>();

                listaProducto = ProdNegAux.listarconSp();
                listaProveedor = ProvNegAux.listarconSp();


                ddlProducto.DataSource = listaProducto;
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataValueField = "IdProducto";
                ddlProducto.DataBind();

                ddlProveedor.DataSource = listaProveedor;
                ddlProveedor.DataTextField = "NombreFantasia";
                ddlProveedor.DataValueField = "IdProveedor";
                ddlProveedor.DataBind();

               
            }
        }

        protected void ImagenCalendario_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendario1.Visible)
            {
                Calendario1.Visible = false;
            }
            else
            {
                Calendario1.Visible = true;
            }
            Calendario1.Attributes.Add("style", "position:absolute");
        }

        protected void Calendario1_SelectionChanged(object sender, EventArgs e)
        {
            txtFecha.Text = Calendario1.SelectedDate.ToString("dd/MM/yyyy");
            Calendario1.Visible = false;
        }

        protected void Calendario1_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            CompraNegocio auxComNeg = new CompraNegocio();
            DateTime fechaCompra = Calendario1.SelectedDate;
            ProductoNegocio prodStock = new ProductoNegocio();

            try
            {
                if (compra == null) { compra = new Compra(); }
                if (compra.Producto == null) { compra.Producto = new Producto(); }
                if (compra.Proveedor == null) { compra.Proveedor = new Proveedor(); }


                compra.Fecha = fechaCompra;
                compra.Producto.IdProducto = int.Parse(ddlProducto.SelectedValue);
                compra.Cantidad = int.Parse(txtCantidad.Text);
                compra.Proveedor.IdProveedor = int.Parse(ddlProveedor.SelectedValue);
                compra.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);

                auxComNeg.alta(compra);

                prodStock.cargarStock(compra.Producto.IdProducto, compra.Cantidad, compra.PrecioCompra);
                Response.Redirect("Compras.aspx", false);
                lblMensaje.Text = "Compra agregada con éxito";

            }

            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();

            }
        }
        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProveedor.aspx");
        }
    }
}