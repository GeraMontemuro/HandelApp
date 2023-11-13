using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listarconSp() //ver si hace falta listar una lista de proveedores o buscar alguno por ID. 
        {
            List<Cliente> listaaux = new List<Cliente>();
            AccesoBD datos = new AccesoBD();

            try
            {
                //datos.setearProcedimiento("SP_ClilistarCliente");
                datos.setearConsulta("select IDCliente as IDCliente, NombreFantasia as Nombre,Cuil as Cuil,Telefono as Tel ,Mail as Mail from Cliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente CliAux = new Cliente();


                    CliAux.IdCliente = (long)datos.Lector["IDCliente"];
                    CliAux.NombreFantasia = (string)datos.Lector["Nombre"];
                    CliAux.Cuil = (string)datos.Lector["Cuil"];
                    CliAux.Telefono = (string)datos.Lector["Tel"];
                    CliAux.Mail = (string)datos.Lector["Mail"];


                    listaaux.Add(CliAux);

                }
                return listaaux;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void alta(Cliente nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Cliente> listanueva = new List<Cliente> ();  

            try
            {
                accesoBD.setearConsulta("Insert into Cliente (NombreFantasia,Cuil,Telefono,Mail) values (@NombreFantasia, @Cuil, @Telefono, @Mail)");
                accesoBD.setearParametro("@Nombrefantasia",nuevo.NombreFantasia);
                accesoBD.setearParametro("@Cuil",nuevo.Cuil);
                accesoBD.setearParametro("@Telefono",nuevo.Telefono);
                accesoBD.setearParametro("@Mail", nuevo.Mail);
                
                accesoBD.ejecutarAccion();

                listanueva = listarconSp();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }


        public Cliente buscar (int Id)
        {
            Cliente ClienteBuscado = new Cliente();
            ClienteNegocio Cnegocio = new ClienteNegocio();
            List<Cliente> ListaFiltro = new List<Cliente>();
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                ListaFiltro = Cnegocio.listarconSp();

                foreach (var Cliente in ListaFiltro)
                {
                    if (Id == (int)Cliente.IdCliente)
                    {
                        ClienteBuscado = Cliente;
                    }
                }

                return ClienteBuscado;
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                accesoBD.cerrarConexion();
            }
        }

        public void modificar(Cliente nuevo)
        {
            /// selecciono el row o el id del dgv 
        }

        public void baja(int id)
        {
            try
            {
                AccesoBD accesoBD = new AccesoBD();

                accesoBD.setearConsulta("delete from Producto where IdProducto = @id");
                accesoBD.setearParametro("@id", id);
                accesoBD.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
