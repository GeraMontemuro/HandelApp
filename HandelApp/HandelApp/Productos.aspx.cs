using dominio;
using negocio;
using System;
using System.Collections;
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
        public List<Producto> ListaDeCargaVenta = new List<Producto>();
        List<Producto> lista = new List<Producto>();
        public List<Producto> ListaFiltrada = new List<Producto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Seguridad.EsAdmin(Session["usuario"]) is dominio.TipoUsuario.ADMIN))
            {
                Session.Add("ERROR", "Se requiere permisos de aministrador.");
                Response.Redirect("Error.aspx", false);
            }


            if (!IsPostBack)
            {
                ProductoNegocio ProductoNegocio = new ProductoNegocio();
                lista = ProductoNegocio.listarconSp();

               



                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }
        }

      

        protected void dgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ProductoNegocio prodNeg = new ProductoNegocio();
            Producto producto = new Producto();

            /*if (e.CommandName == "AgregarProd")
            {               

                if (Session["ListaVenta"] != null)
                {
                    VentaNegocio Negocio = new VentaNegocio();
                    List<Producto> Temporal = (List<Producto>)Session["ListaVenta"];
                    Temporal.Add(Negocio.Buscar(id));
                    FuncionGlobal.Valor += 1;
                    FuncionGlobal.CantidadTotalAsignada(FuncionGlobal.Valor);
                    FuncionGlobal.CantidadTotal();
                    Response.Redirect("Productos.aspx");
                }
                else
                {
                    VentaNegocio Negocio = new VentaNegocio();
                    Session.Add("ListaVenta", (Negocio.Cargar(id, ListaDeCargaVenta)));
                    FuncionGlobal.Valor += 1;
                    FuncionGlobal.CantidadTotalAsignada(FuncionGlobal.Valor);
                    FuncionGlobal.CantidadTotal();
                    Response.Redirect("Productos.aspx");
                }
            }*/
            if (e.CommandName == "Eliminar")
            {               
                try
                {
                    prodNeg.baja(id);
                    Response.Redirect("Productos.aspx", false);
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "mensaje", "alert('Producto asociado a una compra. No puede eliminarse.');", true);
                }

            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect($"~/EditarProducto.aspx?id={id}");
            }
        }

        protected void buscarproducto_Click(object sender, EventArgs e)
        {
            string PalabraBuscada = TxtBuscador.Text;
            AccesoBD accesoBD = new AccesoBD();
            ProductoNegocio PNaux = new ProductoNegocio();

            try
            {

                if (PalabraBuscada != "")
                {
                    accesoBD.setearConsulta("select Pr.IDProducto, Pr.Codigo, Pr.Nombre, Pr.Porcentaje, Pr.Descripcion, Pr.Marcas, M.Descripcion as MDes,Pr.Categorias, C.Descripcion as CDes, Pr.StockTotal, Pr.StockMinimo, Pr.PrecioCompra from Producto Pr \r\ninner join Marcas M on M.IDMarca = Pr.Marcas\r\ninner join Categorias C on C.IDCategoria = Pr.Categorias\r\nwhere Pr.Nombre like ('%" + PalabraBuscada + "%')");
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
                        proaux.CalcularPRecioVenta();

                        ListaFiltrada.Add(proaux);

                    }
                    dgvProductos.DataSource = ListaFiltrada;
                    dgvProductos.DataBind();
                }
                else
                {
                    lista = PNaux.listarconSp();
                    dgvProductos.DataSource = lista;
                    dgvProductos.DataBind();
                }
            }
            catch (Exception)
            {
                dgvProductos.DataSource = lista;
                dgvProductos.DataBind();
            }

            finally
            {
                accesoBD.cerrarConexion();
            }

        }

        protected void btnAgregProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProducto.aspx");
        }
    }
}