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
    public partial class EditarPerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["id"] != null)
                //{
                //    try
                //    {
                //        int id = Convert.ToInt32(Request.QueryString["id"]);
                //        ClienteNegocio cliNeg = new ClienteNegocio();
                //        Cliente cliente = new Cliente();
                //        cliente = cliNeg.buscar(id);

                //        txtNombre.Text = cliente.NombreFantasia;
                //        txtCuil.Text = cliente.Cuil;
                //        txtTelefono.Text = cliente.Telefono;
                //        TxtMail.Text = cliente.Mail;
                //    }
                //    catch (Exception ex)
                //    { throw ex; }
                //}
            }
        }

        protected void btnGuardarEditarPerfil_Click(object sender, EventArgs e)
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
    }
}