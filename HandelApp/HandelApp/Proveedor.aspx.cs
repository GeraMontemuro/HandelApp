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
    public partial class Proveedor : System.Web.UI.Page
    {
        Proveedor Provedor = new Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            List<Proveedor> lista = new List<Proveedor>();
            //lista = negocio.listarconSp();

            dgvProveedor.DataSource = lista;
            dgvProveedor.DataBind();

        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorNegocio Pronegocio = new ProveedorNegocio();

            try
            {
                if (Provedor == null) { Provedor = new Proveedor(); }

                Provedor.


                
                

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvProveedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}