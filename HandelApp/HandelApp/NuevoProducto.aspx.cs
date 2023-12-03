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
                Response.Redirect("Productos.aspx",false);
                //lblMensaje.Text = "Producto agregado con éxito";



            }
            catch (FormatException ex)
            {
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    string script = "alert('El campo de precio no puede dejarse en blanco.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }
                else if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    string script = "alert('El campo de precio no puede dejarse en blanco.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }
                else
                {
                    string script = "alert('Ingresa un precio en números por favor');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }

            }

            catch (OverflowException ex)
            {
                string script = "alert('Superaste la cantidad de caracteres');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }

            catch (Exception ex)
            {
                // lblMensaje.Text = ex.ToString();

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}