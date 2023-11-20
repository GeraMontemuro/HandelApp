using System;
using dominio;
using negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandelApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtUsuario.Text, txtPassword.Text, false);
                if (negocio.loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Inicio.aspx", false);
                }
                else
                {
                    Session.Add("Error", "user o password incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString()); //mandar a mensaje de error
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}