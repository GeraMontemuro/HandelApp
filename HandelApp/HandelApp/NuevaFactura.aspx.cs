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

                VentaRealizada.ProductoVenta = (List<Producto>)Session["ListaVenta"];

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
    }
}