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
    public partial class Proveedores : System.Web.UI.Page
    {
        Proveedor proveedor = new Proveedor();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio provNegocio = new ProveedorNegocio();
            List<Proveedor> lista = new List<Proveedor>();

            lista = provNegocio.listarconSp();

            dgvProveedores.DataSource = lista;
            dgvProveedores.DataBind();

        }

        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            ProveedorNegocio provNeg = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();

            if (e.CommandName == "Eliminar")
            {

                ProveedorNegocio ProveedorAEliminar = new ProveedorNegocio();
                try
                {
                    ProveedorAEliminar.baja(id);
                    Response.Redirect("Proveedores.aspx");
                }
                catch (Exception)
                {

                    throw;
                }
            }         

            else if (e.CommandName == "Editar")
            {
                Response.Redirect($"~/EditarProveedor.aspx?id={id}");
            }

        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            ProveedorNegocio ProNegocio = new ProveedorNegocio ();

            try
            {
                if(proveedor == null) { proveedor = new Proveedor(); }

                proveedor.NombreFantasia = txtNombre.Text;
                proveedor.Cuil = txtCuil.Text;  
                proveedor.Telefono= txtTelefono.Text;   
                proveedor.Mail = txtMail.Text;

                ProNegocio.alta(proveedor);
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}