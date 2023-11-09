using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listarconSp() //ver si hace falta listar una lista de proveedores o buscar alguno por ID. 
        {
            List<Proveedor> listaaux = new List<Proveedor>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearProcedimiento("SP_PrlistarProveedor");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Proveedor ProvAux = new Proveedor();
                   

                    ProvAux.IdProveedor = (int)datos.Lector["IDProveedor"];
                    ProvAux.NombreFantasia = (string)datos.Lector["NombreFantasia"];
                    ProvAux.Cuil = (string)datos.Lector["Cuil"];
                    ProvAux.Telefono = (string)datos.Lector["Telefono"];
                    ProvAux.Mail = (string)datos.Lector["Mail"];                   

                    listaaux.Add(ProvAux);

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
        public void alta(Proveedor nuevo)
        {
            /// ventana de carga de producto, guardo en un objeto producto del back y llamo a la funcion en el onclick de aceptar
        }


        public void modificar(Proveedor nuevo)
        {
            /// selecciono el row o el id del dgv 
        }

        public void baja(Proveedor nuevo)
        {
            /// ver si usamos baja fisica o logica.
        }
    }
}
