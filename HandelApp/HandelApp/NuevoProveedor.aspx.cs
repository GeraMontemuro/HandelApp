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
    public partial class NuevoProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAgregarProv_Click(object sender, EventArgs e)
        {
            ProveedorNegocio ProNegocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();  

            try
            {
                if (proveedor == null) { proveedor = new Proveedor(); }

                proveedor.NombreFantasia = txtNombre.Text;
                proveedor.Cuil = txtCuil.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Mail = txtMail.Text;

                ProNegocio.alta(proveedor);
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnCancelar_Click (object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

    }
}