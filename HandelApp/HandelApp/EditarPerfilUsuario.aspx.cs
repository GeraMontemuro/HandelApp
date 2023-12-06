﻿using dominio;
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


            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario User = (Usuario)Session["usuario"];
                    UsuarioNegocio cliNeg = new UsuarioNegocio();
                    User = cliNeg.buscar(User.Id);
                    txtUsuario.Text = User.User;
                    txtNombre.Text = User.Nombre;
                    txtApellido.Text = User.Apellido;
                    txtEmail.Text = User.Mail;
                    txtFecha.Text = User.FechaNacimiento.ToString();

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