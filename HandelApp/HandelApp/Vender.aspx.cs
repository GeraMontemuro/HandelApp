using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;

namespace HandelApp
{
    public partial class Vender : System.Web.UI.Page
    {
        List<Producto> listaventafinal = new List<Producto>();
        List<Producto> listaProdBuscado = new List<Producto>();
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio CliNegddl = new ClienteNegocio();
                List<Cliente> listaCliente = new List<Cliente>();

                listaCliente = CliNegddl.listarconSp();

                ddlCliente.DataSource = listaCliente;
                ddlCliente.DataTextField = "NombreFantasia";
                ddlCliente.DataValueField = "IDCliente";
                ddlCliente.DataBind();

                ProductoNegocio ProdNegddl = new ProductoNegocio();
                List<Producto> listaProducto = new List<Producto>();

                listaProducto = ProdNegddl.listarconSp();

                ddlProducto.DataSource = listaProducto;
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataValueField = "IDProducto";
                ddlProducto.DataBind();
            }
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente ClienteFiltro = new Cliente();
            ClienteNegocio CliNegFiltro = new ClienteNegocio();
            List<Cliente> listaCliente = new List<Cliente>();

            int idClienteElegido = Convert.ToInt32(ddlCliente.SelectedValue);

            ClienteFiltro = CliNegFiltro.buscar(idClienteElegido);

            listaCliente.Add(ClienteFiltro);

            dgvClienteVenta.DataSource = listaCliente;
            dgvClienteVenta.DataBind();
        }

        protected void btnBuscarCuit_Click(object sender, EventArgs e)
        {
            string Cuil = txtBuscarCuit.Text;
            ClienteNegocio clienteNeg = new ClienteNegocio();
            Cliente clienteBuscado = new Cliente();
            List<Cliente> listaCliente = new List<Cliente>();

            listaCliente.Clear();
            clienteBuscado = clienteNeg.buscarCuitBD(Cuil);

            if (clienteBuscado != null)
            {
                listaCliente.Add(clienteBuscado);
            }

            dgvClienteVenta.DataSource = listaCliente;
            dgvClienteVenta.DataBind();
        }

        protected void btnBusquedaProducto_Click(object sender, EventArgs e)
        {
            string PalabraBuscada = txtBusquedaProducto.Text;
            AccesoBD accesoBD = new AccesoBD();
            List<Producto> listaProdBuscado = new List<Producto>();

            try
            {

                if (PalabraBuscada != "")
                {
                    accesoBD.setearConsulta("select Pr.IDProducto, Pr.Codigo, Pr.Nombre, Pr.Descripcion, Pr.Marcas, Pr.Porcentaje, M.Descripcion as MDes,Pr.Categorias, C.Descripcion as CDes, Pr.StockTotal, Pr.StockMinimo, Pr.PrecioCompra from Producto Pr \r\ninner join Marcas M on M.IDMarca = Pr.Marcas\r\ninner join Categorias C on C.IDCategoria = Pr.Categorias\r\nwhere Pr.Nombre like ('%" + PalabraBuscada + "%')");

                    accesoBD.ejecutarLectura();
                    while (accesoBD.Lector.Read())
                    {
                        Producto proaux = new Producto();
                        proaux.Marca = new Marca();
                        proaux.Categoria = new Categoria();

                        proaux.IdProducto = (int)accesoBD.Lector["IDProducto"];
                        proaux.Codigo = (string)accesoBD.Lector["Codigo"];
                        proaux.Nombre = (string)accesoBD.Lector["Nombre"];
                        proaux.Descripcion = (string)accesoBD.Lector["Descripcion"];
                        proaux.Marca.ID = (int)accesoBD.Lector["Marcas"];
                        if (!(accesoBD.Lector["Marcas"] is DBNull))
                        {
                            proaux.Marca.Descripcion = (string)accesoBD.Lector["MDes"];
                        }
                        else { proaux.Marca.Descripcion = "No tiene"; }
                        proaux.Categoria.Id = (int)accesoBD.Lector["Categorias"];
                        if (!(accesoBD.Lector["Categorias"] is DBNull))
                        {
                            proaux.Categoria.Descripcion = (string)accesoBD.Lector["CDes"];
                        }
                        else { proaux.Categoria.Descripcion = "No tiene"; }
                        proaux.StockTotal = (int)accesoBD.Lector["StockTotal"];
                        proaux.StockMinimo = (int)accesoBD.Lector["StockMinimo"];
                        proaux.PrecioCompra = accesoBD.Lector.GetDecimal(accesoBD.Lector.GetOrdinal("PrecioCompra"));
                        proaux.PorcentajeGanancia = (decimal)accesoBD.Lector["Porcentaje"];
                        proaux.PrecioVenta = 0;
                        proaux.CalcularPRecioVenta();

                        listaProdBuscado.Add(proaux);

                    }
                    dgvProdBuscado.DataSource = listaProdBuscado;
                    dgvProdBuscado.DataBind();
                }

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }

        protected void dgvProdBuscado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ProductoNegocio prodNeg = new ProductoNegocio();


            if (e.CommandName == "SeleccionarProd")
            {
                if (Session["ListaVenta"] != null)
                {

                    VentaNegocio Negocio = new VentaNegocio();
                    List<Producto> Temporal = (List<Producto>)Session["ListaVenta"];
                    Temporal.Add(Negocio.Buscar(id));

                }
                else
                {
                    VentaNegocio negocio = new VentaNegocio();
                    Session.Add("ListaVenta", (negocio.Cargar(id, listaventafinal)));

                }

            }
            listaventafinal = (List<Producto>)Session["ListaVenta"];
            dgvProductoVenta.DataSource = listaventafinal;
            dgvProductoVenta.DataBind();
        }

        protected void dgvProductoVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                Producto aux = new Producto();
                List<Producto> ventas = (List<Producto>)Session["ListaVenta"];
                aux = ventas.Find(x => x.IdProducto == id);
                if (aux != null)
                {
                    ventas.Remove(aux);
                    Session["ListaVenta"] = ventas;

                    dgvProductoVenta.DataSource = ventas;
                    dgvProductoVenta.DataBind();
                }
            }
        }
    }
}