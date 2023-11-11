using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ProductoNegocio ProductoNegocio = new ProductoNegocio();
            List<Producto> lista = new List<Producto>();
            lista = ProductoNegocio.listarconSp();

            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();

        }
    }
}