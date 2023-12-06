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
    public partial class Compras : System.Web.UI.Page
    {
        Compra compra = new Compra();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                CompraNegocio comNeg = new CompraNegocio();
                List<Compra> lista = new List<Compra>();
                lista = comNeg.listarconSp();

                dgvCompras.DataSource = lista;
                dgvCompras.DataBind();
            }
        }     

        protected void dgvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);            
            CompraNegocio comNeg = new CompraNegocio();
            Compra compra = new Compra();

            if (e.CommandName == "Eliminar")
            {
                try
                {
                    comNeg.baja(id);
                    Response.Redirect("Compras.aspx", false);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect($"~/EditarCompra.aspx?id={id}");
            }
        }

        protected void btnNvaCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaCompra.aspx");
        }
    }
}