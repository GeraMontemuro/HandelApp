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
    public partial class NewLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GuardarNvoUSuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario user = new Usuario(txtUsuario.Text, txtPassword.Text, false);
                UsuarioNegocio negocio = new UsuarioNegocio();
                user.User = txtUsuario.Text;
                user.Pass = txtPassword.Text;
                user.TipoUsuario = TipoUsuario.NORMAL;
                int id = negocio.InsertarNuevoLogin(user);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}