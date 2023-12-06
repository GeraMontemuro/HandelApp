using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace HandelApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is NuevoProducto || Page is Productos || Page is Proveedores || Page is NuevoProveedor || Page is NewLogin || Page is NuevoProveedor ||Page is EditarProveedor || Page is EditarProducto)
                if (!(Seguridad.EsAdmin(Session["usuario"]) is dominio.TipoUsuario.ADMIN))
                {
                    Session.Add("ERROR", "Se requiere permisos de aministrador.");
                    Response.Redirect("Error.aspx", false);
                }
            //imaAvatar.ImageUrl = "~/Logos/logoSolo.png";
            if (!(Page is Inicio))
            {
                if (!Seguridad.SessionActiva(Session["usuario"]))
                {

                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblUsuario.Text = user.User;
                    //if(user.ImagenPerfil != null)
                    imaAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;

                }
            }

        }


        protected void btnEditarPerfil_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("EditarPerfilUsuario.aspx");
        }

        protected void btnAgregarNuevoUsuario_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("NewLogin.aspx");
        }

        protected void btnSalirSesion_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}