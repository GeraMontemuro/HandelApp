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
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = new List<Cliente>();
            lista = negocio.listarconSp();


            dgvClientes.DataSource = lista;
            dgvClientes.DataBind();


        }
    }
}