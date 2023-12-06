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
            
                if (!Seguridad.SessionActiva(Session["usuario"]))
                {

                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblUsuario.Text = user.User;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                    {
                        imaAvatar.ImageUrl = "~/Imagenes/" + user.ImagenPerfil;

                    }
                    else
                    {
                        imaAvatar.ImageUrl = "https://www.bing.com/ck/a?!&&p=f1cb5705983cae33JmltdHM9MTcwMTgyMDgwMCZpZ3VpZD0zYTRjYmNiMC0yYWY0LTZlMTMtMmFlNi1hZDdhMmI1MTZmZGUmaW5zaWQ9NTU0NA&ptn=3&ver=2&hsh=3&fclid=3a4cbcb0-2af4-6e13-2ae6-ad7a2b516fde&u=a1L2ltYWdlcy9zZWFyY2g_cT1sb2dvIHZhY2lvIGRlIHVzdWFyaW8mRk9STT1JUUZSQkEmaWQ9NjA1NjM0QkM2MEMwREMxM0VGQUQ2QTkzQ0VGNTk0MDRCQzgzQzQ3Rg&ntb=1";
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