using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Vender : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio ProductoNegocio = new ProductoNegocio();
            List<Producto> lista = new List<Producto>();
            lista = ProductoNegocio.listarconSp();         

            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();
        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}