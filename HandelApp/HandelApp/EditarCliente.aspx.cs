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
    public partial class EditarCliente : System.Web.UI.Page
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
                        ClienteNegocio cliNeg = new ClienteNegocio();
                        Cliente cliente = new Cliente();
                        cliente = cliNeg.buscar(id);

                        txtNombre.Text = cliente.NombreFantasia;
                        txtCuil.Text = cliente.Cuil;
                        txtTelefono.Text = cliente.Telefono;
                        TxtMail.Text = cliente.Mail;
                    }
                    catch (Exception ex)
                    { throw ex; }
                }
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            ClienteNegocio auxCliNegocio = new ClienteNegocio();

            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                Cliente cliente = auxCliNegocio.buscar(id);

                cliente.NombreFantasia = txtNombre.Text;
                cliente.Cuil = txtCuil.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Mail = TxtMail.Text;

                auxCliNegocio.modificar(cliente);

                Response.Redirect("Clientes.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
    }
}