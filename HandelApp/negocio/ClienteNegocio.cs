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
                datos.setearProcedimiento("SP_ClilistarCliente");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente CliAux = new Cliente();


                    CliAux.IdCliente= (int)datos.Lector["IDCliente"];
                    CliAux.NombreFantasia = (string)datos.Lector["NombreFantasia"];
                    CliAux.Cuil = (string)datos.Lector["Cuil"];
                    CliAux.Telefono = (string)datos.Lector["Telefono"];
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
    }
}
