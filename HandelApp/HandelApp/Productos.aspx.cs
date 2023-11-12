using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Productos : System.Web.UI.Page
    {   
        Producto producto = new Producto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio ProductoNegocio = new ProductoNegocio();
                List<Producto> lista = new List<Producto>();
                lista = ProductoNegocio.listarconSp();

                Marca marcaaux = new Marca();
                MarcaNegocio marNegAux = new MarcaNegocio();
                List<Marca> listaMarcas = new List<Marca>();

                Categoria categoriaaux = new Categoria();
                CategoriaNegocio catNegAux = new CategoriaNegocio();
                List<Categoria> listaCategorias = new List<Categoria>();

                listaMarcas = marNegAux.listar();
                listaCategorias = catNegAux.listar();


                ddlMarca.DataSource = listaMarcas;
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataBind();

                ddlCategoria.DataSource = listaCategorias;
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();

                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }
        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            ProductoNegocio auxProdNegocio = new ProductoNegocio();

            try
            {
                if (producto == null) { producto = new Producto(); }
                if (producto.Marca == null) { producto.Marca = new Marca(); }
                if (producto.Categoria == null) { producto.Categoria = new Categoria(); }


                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Codigo = txtCodigo.Text;
                producto.Marca.ID = int.Parse(ddlMarca.SelectedValue);
                producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                producto.StockTotal = int.Parse(txtStockTotal.Text);
                producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                producto.PrecioCompra = decimal.Parse(txtPrecio.Text);

                auxProdNegocio.alta(producto);
                Response.Redirect("Productos.aspx");
                lblMensaje.Text = "Ingresa un precio en números por favor";


            }
            catch (FormatException ex)
            {
                // lblMensaje.Text = "Ingresa un precio en números por favor";
                
            }

            catch (OverflowException ex)
            {
                //lblMensaje.Text = "Superaste la cantidad de caracteres";
                
            }

            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();
                
            }
        }
    }
}