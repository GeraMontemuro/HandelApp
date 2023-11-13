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
    public partial class Clientes : System.Web.UI.Page
    {
        Cliente Cliente = new Cliente();  
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = new List<Cliente>();
            lista = negocio.listarconSp();


            dgvClientes.DataSource = lista;
            dgvClientes.DataBind();


        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            ClienteNegocio CliNegocio = new ClienteNegocio();

            try
            {
                if(Cliente == null) { Cliente = new Cliente(); }

                Cliente.NombreFantasia = txtNombre.Text;
                Cliente.Cuil = txtCuil.Text;
                Cliente.Telefono = txtTelefono.Text;
                Cliente.Mail = txtMail.Text;

                CliNegocio.alta(Cliente);
                Response.Redirect("Clientes.aspx");


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {

                ClienteNegocio CLienteAEliminar = new ClienteNegocio();
                try
                {
                    CLienteAEliminar.baja(id);
                    Response.Redirect("Clientes.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else if (e.CommandName == "Editar")
            {

            }
        }
    }
    }
}