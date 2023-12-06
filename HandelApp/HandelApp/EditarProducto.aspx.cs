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
    public partial class EditarProducto : System.Web.UI.Page
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
                        ProductoNegocio prodNeg = new ProductoNegocio();
                        Producto producto = new Producto();
                        producto = prodNeg.buscar(id);

                        txtNombre.Text = producto.Nombre;
                        txtCodigo.Text = producto.Codigo;
                        txtDescripcion.Text = producto.Descripcion;
                        txtStockMinimo.Text = producto.StockMinimo.ToString();
                        txtPrecio.Text = producto.PrecioCompra.ToString();
                        txtPorcentaje.Text = producto.PorcentajeGanancia.ToString();
                        txtMarca.Text = producto.Marca.Descripcion.ToString();
                        txtCategoria.Text = producto.Categoria.Descripcion.ToString();
                        txtStockTotal.Text = producto.StockTotal.ToString();

                    }
                    catch (Exception ex)
                    { throw ex; }
                }
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            ProductoNegocio auxProdNegocio = new ProductoNegocio();

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Producto producto = auxProdNegocio.buscar(id);

                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                producto.PorcentajeGanancia = decimal.Parse(txtPorcentaje.Text);
                producto.PrecioCompra = decimal.Parse(txtPrecio.Text);

                auxProdNegocio.modificar(producto);

                Response.Redirect("Productos.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
 
   
       
}
