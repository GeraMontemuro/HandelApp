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
        private Producto pro = new Producto();
        private List<Producto> ListadeVenta = new List<Producto>();
        decimal AuxPrecio = 0;
        int contador;
        string PrecioTotal;
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cliente ClienteFiltro = new Cliente();
                ClienteNegocio CliNegFiltro = new ClienteNegocio();
                List<Cliente> listaCliente = new List<Cliente>();

                listaCliente = CliNegFiltro.listarconSp();

                ddlCliente.DataSource = listaCliente;
                ddlCliente.DataValueField = "NombreFantasia";
                ddlCliente.DataBind();

                foreach (var Cliente in listaCliente)
                {
                    if (Cliente.NombreFantasia == ddlCliente.SelectedValue)
                    {
                        CuilCliente.Text = Cliente.Cuil;
                        TelefonoCliente.Text = Cliente.Telefono;
                        MailCliente.Text = Cliente.Mail;

                    }
                }
                try
                {
                    int Idaux = int.Parse(Request.QueryString["id"]);
                    pro.IdProducto = Idaux;

                    if (Session["ListaVenta"] == null)
                    {
                        VentaNegocio Negocio = new VentaNegocio();
                        Session.Add("ListaVenta", (Negocio.Cargar(Idaux, ListadeVenta)));

                    }
                    else
                    {
                        VentaNegocio Negocio = new VentaNegocio();
                        List<Producto> Temporal1 = (List<Producto>)Session["ListaVenta"];
                        Temporal1.Add(Negocio.Buscar(Idaux));

                    }

                    List<Producto> Temporal = (List<Producto>)Session["ListaVenta"];

                    dgvVentas.DataSource = Temporal;
                    dgvVentas.DataBind();

                }
                catch (Exception)

                {
                    List<Producto> Temporal = (List<Producto>)Session["ListaVenta"];

                    dgvVentas.DataSource = Temporal;
                    dgvVentas.DataBind();

                }
                finally
                {
                    List<Producto> Temporal2 = new List<Producto>();
                    Temporal2 = (List<Producto>)Session["ListaVenta"];

                    if (Temporal2 != null)
                    {
                        foreach (Producto item in Temporal2)
                        {
                            AuxPrecio += item.PrecioCompra;
                            contador = Temporal2.Count();
                            FuncionGlobal.CantidadTotalAsignada(contador);
                            FuncionGlobal.CantidadTotal();
                        }

                    }

                    PrecioTotal = string.Format("{0:C}", AuxPrecio);
                    TextPrecioTotal.Text = PrecioTotal;
                }

            }
            else
            {
                List<Producto> Temporal2 = new List<Producto>();
                Temporal2 = (List<Producto>)Session["ListaVenta"];

                if (Temporal2 != null)
                {
                    foreach (Producto item in Temporal2)
                    {
                        AuxPrecio += item.PrecioCompra;
                        FuncionGlobal.CantidadTotalAsignada(contador);
                        FuncionGlobal.CantidadTotal();
                    }

                }

                PrecioTotal = string.Format("{0:C}", AuxPrecio);
                TextPrecioTotal.Text = PrecioTotal;
            }

        }
        
        public void BtnFactura_Click(object sender, EventArgs e)
        {
            Response.Redirect("Factura.aspx"); 
        }
               

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cliente ClienteFiltro = new Cliente();
            ClienteNegocio CliNegFiltro = new ClienteNegocio();
            List<Cliente> listaCliente = new List<Cliente>();

            listaCliente = CliNegFiltro.listarconSp();

            foreach (var Cliente in listaCliente)
            {
                if (Cliente.NombreFantasia == ddlCliente.SelectedValue)
                {
                    CuilCliente.Text = Cliente.Cuil;
                    TelefonoCliente.Text = Cliente.Telefono;
                    MailCliente.Text = Cliente.Mail;

                }
            }
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            LinkButton btn = (LinkButton)e.CommandSource;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            TextBox txtCantidad = (TextBox)row.FindControl("txtStockavender");
            int cantidad = Convert.ToInt32(txtCantidad.Text);
           
            ProductoNegocio auxProductonegocio = new ProductoNegocio();
            Producto Prodaux = new Producto();

            Prodaux = auxProductonegocio.buscar(id);

            if (e.CommandName == "Restar" && Prodaux.StockTotal > 0)
            {
                
                cantidad--;
            }
            else if (e.CommandName == "Sumar" && cantidad <= Prodaux.StockTotal)
            {
                
                cantidad++;
            }
            else if (e.CommandName == "Eliminar")
            {

                AuxPrecio = 0;
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
                            AuxPrecio += item.PrecioCompra;
                            contador = ventas.Count();
                            FuncionGlobal.CantidadTotalAsignada(contador);
                            FuncionGlobal.CantidadTotal();

                        }
                        PrecioTotal = string.Format("{0:C}", AuxPrecio);
                        TextPrecioTotal.Text = PrecioTotal;


                    }
                    dgvVentas.DataSource = ventas;
                    dgvVentas.DataBind();
                }
            }
            txtCantidad.Text = cantidad.ToString();

        }
    }
}