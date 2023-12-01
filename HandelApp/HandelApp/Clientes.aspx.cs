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
    public partial class Clientes : System.Web.UI.Page
    {
        Cliente Cliente = new Cliente();
        List<Cliente> lista = new List<Cliente>();
        public List<Cliente> ListaFiltrada = new List<Cliente>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try { 
                ClienteNegocio negocio = new ClienteNegocio();                
                lista = negocio.listarconSp();


                dgvClientes.DataSource = lista;
                dgvClientes.DataBind();

            }
            catch (FormatException ex)
            {
                // lblMensaje.Text = "";
                
            }


}

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio CliNegocio = new ClienteNegocio();

            try
            {
                if(Cliente == null) { Cliente = new Cliente(); }

                Cliente.NombreFantasia = txtNombre.Text;
                Cliente.Cuil = txtCuil.Text;
                Cliente.Telefono = txtTelefono.Text;
                Cliente.Mail = txtMail.Text;

                CliNegocio.alta(Cliente);
                Response.Redirect("Clientes.aspx");


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Eliminar")
            {

                ClienteNegocio CLienteAEliminar = new ClienteNegocio();
                try
                {
                    CLienteAEliminar.baja(id);
                   
                    Response.Redirect("Clientes.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else if (e.CommandName == "Editar")
            {
                Response.Redirect($"~/EditarCliente.aspx?id={id}");
            }
        }

        protected void buscarcliente_Click(object sender, EventArgs e)
        {
            string PalabraBuscada = TxtBuscador.Text;
            AccesoBD accesoBD = new AccesoBD();
            ClienteNegocio Clneg = new ClienteNegocio();


            try
            {
                if (PalabraBuscada != "")
                {
                    accesoBD.setearConsulta("select IDCliente as IDCliente, NombreFantasia as Nombre,Cuil as Cuil,Telefono as Tel ,Mail as Mail from Cliente where NombreFantasia like ('%" + PalabraBuscada + "%')");
                    accesoBD.ejecutarLectura();

                    while (accesoBD.Lector.Read())
                    {
                        Cliente Claux = new Cliente();

                        Claux.IdCliente = (long)accesoBD.Lector["IDCliente"];
                        Claux.NombreFantasia = (string)accesoBD.Lector["Nombre"];
                        Claux.Cuil = (string)accesoBD.Lector["Cuil"];
                        Claux.Telefono = (string)accesoBD.Lector["Tel"];
                        Claux.Mail = (string)accesoBD.Lector["Mail"];

                        ListaFiltrada.Add(Claux);
                    }
                    dgvClientes.DataSource = ListaFiltrada;
                    dgvClientes.DataBind();
                }
                else
                {
                    lista = Clneg.listarconSp();
                    dgvClientes.DataSource = lista;
                    dgvClientes.DataBind();
                }

            }
            catch (Exception)
            {
                lista = Clneg.listarconSp();
                dgvClientes.DataSource = lista;
                dgvClientes.DataBind();
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }
    }
    }
