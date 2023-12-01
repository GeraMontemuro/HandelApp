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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewLogin.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio Useraux = new UsuarioNegocio();
                string ruta = Server.MapPath("./Imagenes/");
                Usuario User = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + User.Id + ".jpg");

                User.ImagenPerfil = "perfil-" + User.Id + ".jpg";
                User.Nombre = txtNombre.Text;
                User.Apellido = txtApellido.Text;
                User.Mail = txtEmail.Text;
                // User.FechaNacimiento = (DateTime) txtFecha.Text;
                Useraux.actualizar(User);

                //Image img = (Image)Master.FindControl("imgAvatar");
                //img.ImageUrl = "~/Imagenes/" + User.ImagenPerfil;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnNuevoUsuario_Click1(object sender, EventArgs e)
        {
            Response.Redirect("NewLogin.aspx");
        }
    }
}