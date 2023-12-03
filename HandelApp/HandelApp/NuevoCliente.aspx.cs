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
    public partial class NuevoCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {

            ClienteNegocio CliNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                if (cliente == null) { cliente = new Cliente(); }

                cliente.NombreFantasia = txtNombre.Text;
                cliente.Cuil = txtCuil.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Mail = txtMail.Text;

                CliNegocio.alta(cliente);
                Response.Redirect("Clientes.aspx");


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
    }
}