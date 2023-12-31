﻿using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;

namespace HandelApp
{
    public partial class Vender : System.Web.UI.Page
    {

        List<Producto> listaventafinal = new List<Producto>();
        List<Producto> listaProdBuscado = new List<Producto>();
        decimal AuxPrecio = 0;
        string PrecioTotal;
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
                ddlProducto.DataTextField = "Codigo";
                ddlProducto.DataValueField = "IDProducto";
                ddlProducto.DataBind();

                if (Session["ListaVentas"] != null)
                {
                    PrecioTotal = "$ 0,00";
                    TxtPrecioTotal.Text = PrecioTotal;
                }
                else
                {
                    List<Producto> Temporal2 = new List<Producto>();
                    Temporal2 = (List<Producto>)Session["ListaVenta"];

                    if (Temporal2 != null)
                    {
                        foreach (Producto item in Temporal2)
                        {
                            AuxPrecio += item.PrecioFinal;
                        }
                    }
                    PrecioTotal = string.Format("{0:C}", AuxPrecio);
                    TxtPrecioTotal.Text = PrecioTotal;
                }

                listaventafinal = (List<Producto>)Session["ListaVenta"];
                dgvProductoVenta.DataSource = listaventafinal;
                dgvProductoVenta.DataBind();

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

            Session["ListaCliente"] = ClienteFiltro;

            dgvClienteVenta.DataSource = listaCliente;
            dgvClienteVenta.DataBind();
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Producto ProductoFiltro = new Producto();
            ProductoNegocio ProNegFiltro = new ProductoNegocio();
            List<Producto> listaProducto = new List<Producto>();

            int idProductoElegido = Convert.ToInt32(ddlProducto.SelectedValue);
            ProductoFiltro = ProNegFiltro.buscar(idProductoElegido);
            listaProducto.Add(ProductoFiltro);

            dgvProdBuscado.DataSource = listaProducto;
            dgvProdBuscado.DataBind();
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
                Session["ListaCliente"] = clienteBuscado;
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
                else
                {

                    List<Productos> lala = new List<Productos>();
                    dgvProdBuscado.DataSource = lala;
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
            LinkButton btn = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");



            if (e.CommandName == "SeleccionarProd")
            {
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                ProductoNegocio prodNeg = new ProductoNegocio();
                Producto proaux = new Producto();
                proaux = prodNeg.buscar(id);

                if (proaux.StockTotal > cantidad)
                {
                    proaux.Cantidad = cantidad;
                    decimal Cantidad = decimal.Parse(proaux.Cantidad.ToString());
                    proaux.PrecioFinal = cantidad * proaux.PrecioVenta;

                    if (Session["ListaVenta"] != null)
                    {
                        VentaNegocio Negocio = new VentaNegocio();
                        List<Producto> Temporal = (List<Producto>)Session["ListaVenta"];
                        Temporal.Add(proaux);
                    }
                    else
                    {
                        VentaNegocio negocio = new VentaNegocio();
                        Session.Add("ListaVenta", (negocio.Cargar(id, listaventafinal, proaux.Cantidad, proaux.PrecioFinal)));

                    }
                    lblMensajestock.Visible = false;
                }
                else
                {
                    lblMensajestock.Text = "La compra excede el stock disponible.";
                    lblMensajestock.Visible = true;
                }

            }
            List<Producto> Temporal2 = new List<Producto>();
            Temporal2 = (List<Producto>)Session["ListaVenta"];

            if (Temporal2 != null)
            {
                foreach (Producto item in Temporal2)
                {
                    AuxPrecio += item.PrecioFinal;
                }
            }
            PrecioTotal = string.Format("{0:C}", AuxPrecio);
            TxtPrecioTotal.Text = PrecioTotal;
            listaventafinal = (List<Producto>)Session["ListaVenta"];
            dgvProductoVenta.DataSource = listaventafinal;
            dgvProductoVenta.DataBind();
        }

        protected void dgvProductoVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {
                AuxPrecio = 0;
                int contador = 0;
                Producto aux = new Producto();
                List<Producto> ventas = (List<Producto>)Session["ListaVenta"];
                aux = ventas.Find(x => x.IdProducto == id);
                if (aux != null)
                {
                    ventas.Remove(aux);
                    Session["ListaVenta"] = ventas;

                    if (ventas != null)
                    {
                        foreach (Producto item in ventas)
                        {
                            AuxPrecio += item.PrecioFinal;
                            contador++;
                        }
                        PrecioTotal = string.Format("{0:C}", AuxPrecio);
                        TxtPrecioTotal.Text = PrecioTotal;
                    }
                    if (contador <= 0)
                    {
                        PrecioTotal = "$ 0,00";
                        TxtPrecioTotal.Text = PrecioTotal;
                    }

                    dgvProductoVenta.DataSource = ventas;
                    dgvProductoVenta.DataBind();
                }
            }
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            List<Productos> lala = new List<Productos>();
            dgvProdBuscado.DataSource = lala;
            dgvProdBuscado.DataBind();
        }

        protected void btnAgregarFactura_Click(object sender, EventArgs e)
        {
            ///1) GUARDAR EL OBJETO EN BASE DE DATOS
            Venta ventaBD = new Venta();

            ventaBD.DiaVenta = DateTime.Today;
            ventaBD.TotalVenta = decimal.Parse(TxtPrecioTotal.Text, NumberStyles.Currency);
            ventaBD.ClienteVenta = (Cliente)Session["ListaCliente"];
            ventaBD.ProductoVenta = (List<Producto>)Session["ListaVenta"];
            ventaBD.UsuarioVenta = (Usuario)Session["usuario"];


            ///2) MODIFICAR STOCK DE LOS PRODUCTOS
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaModificar = (List<Producto>)Session["ListaVenta"];

            if (listaModificar != null)
            {
                foreach (Producto item in listaModificar)
                {
                    productoNegocio.modificarStock(item.IdProducto, item.Cantidad);
                }
            }
            
            Response.Redirect("NuevaFactura.aspx",false);
        }

    }
}