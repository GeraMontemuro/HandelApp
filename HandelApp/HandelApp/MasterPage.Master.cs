using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace HandelApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Inicio))
            {
                if (!Seguridad.SessionActiva(Session["usuario"]))
                {
                    Response.Redirect("Inicio.aspx", false);
                }
            }

        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); //vuelve siemmpre a inicio
        }
    }
}