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
        List<Proveedor> lista = new List<Proveedor>();
        public List<Proveedor> ListaFiltrada = new List<Proveedor>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProveedorNegocio provNegocio = new ProveedorNegocio();           
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

       /* protected void btnAgregarProd_Click(object sender, EventArgs e)
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

        }*/
        protected void AgregarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevoProveedor.aspx", false);
        }

        protected void buscarproveedor_Click(object sender, EventArgs e)
        {
            string PalabraBuscada = TxtBuscador.Text;
            AccesoBD accesoBD = new AccesoBD();
            ProveedorNegocio PrNeg = new ProveedorNegocio();

            try
            {
                if (PalabraBuscada != "")
                {
                    accesoBD.setearConsulta("Select IDProveedor, NombreFantasia, Cuil, Telefono, Mail from Proveedor where NombreFantasia like ('%" + PalabraBuscada + "%')");
                    accesoBD.ejecutarLectura();

                    while (accesoBD.Lector.Read())
                    {
                        Proveedor ProvAux = new Proveedor();


                        ProvAux.IdProveedor = (long)accesoBD.Lector["IDProveedor"];
                        ProvAux.NombreFantasia = (string)accesoBD.Lector["NombreFantasia"];
                        ProvAux.Cuil = (string)accesoBD.Lector["Cuil"];
                        ProvAux.Telefono = (string)accesoBD.Lector["Telefono"];
                        ProvAux.Mail = (string)accesoBD.Lector["Mail"];

                        ListaFiltrada.Add(ProvAux);
                    }
                    dgvProveedores.DataSource = ListaFiltrada;
                    dgvProveedores.DataBind();
                }
                else
                {
                    lista = PrNeg.listarconSp();
                    dgvProveedores.DataSource = lista;
                    dgvProveedores.DataBind();
                }

            }
            catch (Exception)
            {
                lista = PrNeg.listarconSp();
                dgvProveedores.DataSource = lista;
                dgvProveedores.DataBind();
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }
    }
}