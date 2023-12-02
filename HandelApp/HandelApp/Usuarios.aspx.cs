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
    public partial class Usuarios : System.Web.UI.Page
    {
        Usuario usuario;
        List<Usuario> lista = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                lista = negocio.listarconSp();

                dgvUsuarios.DataSource = lista;
                dgvUsuarios.DataBind();

            }
            catch (FormatException ex)
            {
                // lblMensaje.Text = "";

            }
        }

    }
}