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
    public partial class Proveedores : System.Web.UI.Page
    {
        Proveedor proveedor = new Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio provNegocio = new ProveedorNegocio();
            List<Proveedor> lista = new List<Proveedor>();

            lista = provNegocio.listarconSp();

            dgvProveedores.DataSource = lista;
            dgvProveedores.DataBind();

        }

        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {

        }
    }
}