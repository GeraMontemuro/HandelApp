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
            if (!Seguridad.SessionActiva(Session["usuario"]))
                Response.Redirect("Default.aspx", false);
<<<<<<< HEAD

            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtUsuario.Text = usuario.User;
=======
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    try
                    {
                        int id = Convert.ToInt32(Request.QueryString["Id"]);
                        UsuarioNegocio cliNeg = new UsuarioNegocio();
                        Usuario cliente = new Usuario();
                        cliente = cliNeg.buscar(id);
                        if ((Seguridad.SessionActiva(Session["usuario"])) == true)
                        {
                            txtUsuario.Text = cliente.User;
                            txtNombre.Text = cliente.Nombre;
                            txtApellido.Text = cliente.Apellido;
                            txtApellido.Text = cliente.Mail;
                            txtFecha.Text = cliente.FechaNacimiento.ToString();

                        }
                        txtUsuario.Text = Master.FindControl("lblUsuario").ToString();

                        cliente.Nombre = txtNombre.Text;
                        cliente.Apellido = txtApellido.Text;
                        cliente.Mail = txtEmail.Text;
                        cliente.FechaNacimiento = DateTime.Parse(txtFecha.Text);

                        cliNeg.actualizar(cliente);

                    }
                    catch (Exception ex)
                    { throw ex; }
>>>>>>> 20e1802c63f7567b8a75805f157f5f45eed61189
                }
            }
        }

        protected void btnGuardarEditarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio Useraux = new UsuarioNegocio();
                Usuario User = (Usuario)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + User.Id + ".jpg");
                    User.ImagenPerfil = "perfil-" + User.Id + ".jpg";

                }


                User.Nombre = txtNombre.Text;
                User.Apellido = txtApellido.Text;
                User.Mail = txtEmail.Text;
                User.FechaNacimiento = DateTime.Parse(txtFecha.Text);
                Useraux.actualizar(User);

                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Imagenes/" + User.ImagenPerfil;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}