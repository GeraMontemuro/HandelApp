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
    public partial class EditarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        CompraNegocio comNeg = new CompraNegocio();
                        Compra compra = new Compra();
                        compra = comNeg.buscar(id);

                        txtFecha.Text = compra.Fecha.ToString("dd-MM-yyyy");
                        ddlProducto.SelectedValue = compra.Producto.IdProducto.ToString();
                        txtCantidad.Text = compra.Cantidad.ToString();
                        txtPrecio.Text = compra.PrecioCompra.ToString();
                        ddlProveedor.SelectedValue = compra.Proveedor.IdProveedor.ToString();

                    }
                    catch (Exception ex)
                    { throw ex; }
                }
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            CompraNegocio auxComNeg = new CompraNegocio();
            DateTime fechaCompra = DateTime.Parse(txtFecha.Text);

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Compra compra = auxComNeg.buscar(id);                

                compra.Fecha = fechaCompra;
                compra.Producto.IdProducto = int.Parse(ddlProducto.SelectedValue);
                compra.Cantidad = int.Parse(txtCantidad.Text);
                compra.PrecioCompra = decimal.Parse(txtPrecio.Text);
                compra.Proveedor.IdProveedor = int.Parse(ddlProveedor.SelectedValue);

                auxComNeg.modificar(compra);

                Response.Redirect("Compra.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }
    }
}