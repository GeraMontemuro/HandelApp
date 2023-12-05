using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class NuevoProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                MarcaNegocio marNegAux = new MarcaNegocio();
                List<Marca> listaMarcas = new List<Marca>();

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


            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductoNegocio auxProdNegocio = new ProductoNegocio();
            Producto producto = new Producto();
            Page.Validate();
            if(!Page.IsValid) { return; }
  
            try
            {

                if (producto == null) { producto = new Producto(); }
                if (producto.Marca == null) { producto.Marca = new Marca(); }
                if (producto.Categoria == null) { producto.Categoria = new Categoria(); }

                Marca marcaaux = new Marca();
                MarcaNegocio marNegAux = new MarcaNegocio();
                List<Marca> listaMarcas = new List<Marca>();

                Categoria categoriaaux = new Categoria();
                CategoriaNegocio catNegAux = new CategoriaNegocio();
                List<Categoria> listaCategorias = new List<Categoria>();

                listaMarcas = marNegAux.listar();
                listaCategorias = catNegAux.listar();


                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Codigo = txtCodigo.Text;
                producto.Marca.ID = int.Parse(ddlMarca.SelectedValue);
                producto.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                producto.StockTotal = int.Parse(txtStockTotal.Text);
                producto.StockMinimo = int.Parse(txtStockMinimo.Text);
                producto.PrecioCompra = decimal.Parse(txtPrecio.Text);
                producto.PorcentajeGanancia = decimal.Parse(txtPorcentaje.Text);

                auxProdNegocio.alta(producto);
                Response.Redirect("Productos.aspx", false);
                //lblMensaje.Text = "Producto agregado con éxito";



            }
            catch (FormatException ex)
            {
                throw ex;
            }        

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }
    }
}