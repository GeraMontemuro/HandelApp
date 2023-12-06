using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class NuevaFactura : System.Web.UI.Page
    {
        Venta VentaRealizada = new Venta();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                
                txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
                VentaRealizada.UsuarioVenta = new Usuario();

                VentaRealizada.ProductoVenta = (List<Producto>)Session["ListaVenta"];
                VentaRealizada.ClienteVenta = (Cliente)Session["ListaCliente"];
                VentaRealizada.UsuarioVenta = (Usuario)Session["usuario"];

                txtVendedor.Text = VentaRealizada.UsuarioVenta.User;
                txtNombreCliente.Text = VentaRealizada.ClienteVenta.NombreFantasia.ToString();
                txtCuil.Text = VentaRealizada.ClienteVenta.Cuil.ToString();
                txtMail.Text = VentaRealizada.ClienteVenta.Mail.ToString();
                txtTelefono.Text = VentaRealizada.ClienteVenta.Telefono.ToString();


                dgvProdFactura.DataSource = (List<Producto>)VentaRealizada.ProductoVenta;
                dgvProdFactura.DataBind();



                if (VentaRealizada.ProductoVenta != null)
                {
                    foreach (Producto item in VentaRealizada.ProductoVenta)
                    {
                        VentaRealizada.TotalVenta += item.PrecioFinal;
                    }
                }

                txtTotalFactura.Text = string.Format("{0:C}", VentaRealizada.TotalVenta);



            }

        }

        protected void Finalizar_Click(object sender, EventArgs e)
        {
            List<Producto> LimpiarSessionPro = (List<Producto>)Session["ListaVenta"];
            LimpiarSessionPro.Clear();

            Cliente LimpiarSessionCliente = (Cliente)Session["ListaCliente"];
            LimpiarSessionCliente = new Cliente();

            Usuario LimpiarSessionUsuario = (Usuario)Session["usuario"];
            LimpiarSessionUsuario = new Usuario();
            
            Response.Redirect("Inicio.aspx", false);
        }
    }
}