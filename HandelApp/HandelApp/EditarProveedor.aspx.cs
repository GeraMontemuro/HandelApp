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
    public partial class EditarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["id"]);
                        ProveedorNegocio cliNeg = new ProveedorNegocio();
                        Proveedor proveedor = new Proveedor();
                        proveedor = cliNeg.buscar(id);

                        txtNombre.Text = proveedor.NombreFantasia;
                        txtCuil.Text = proveedor.Cuil;
                        txtTelefono.Text = proveedor.Telefono;
                        TxtMail.Text = proveedor.Mail;
                    }
                    catch (Exception ex)
                    { throw ex; }
                }
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            ProveedorNegocio auxProvNegocio = new ProveedorNegocio();

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Proveedor proveedor = auxProvNegocio.buscar(id);

                proveedor.NombreFantasia = txtNombre.Text;
                proveedor.Cuil = txtCuil.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Mail = TxtMail.Text;

                auxProvNegocio.modificar(proveedor);

                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    
    }
}