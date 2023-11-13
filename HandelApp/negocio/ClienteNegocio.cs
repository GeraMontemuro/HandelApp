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
            /// ventana de carga de producto, guardo en un objeto producto del back y llamo a la funcion en el onclick de aceptar
        }


        public void modificar(Cliente nuevo)
        {
            /// selecciono el row o el id del dgv 
        }

        public void baja(Cliente nuevo)
        {
            /// ver si usamos baja fisica o logica.
        }

        
    }
}
