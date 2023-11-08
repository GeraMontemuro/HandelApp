using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listarconSp()
        {
            List<Producto> listaaux = new List<Producto>();
            AccesoBD datos = new AccesoBD();

            try
            {
                datos.setearProcedimiento("SP_listarProducto");
                datos.ejecutarLectura();

                while (datos.Lector.Read()){

                    Producto ProdAux = new Producto();
                    Marca MarcAux = new Marca();
                    Categoria CatAux = new Categoria();

                    ProdAux.Codigo = (int)datos.Lector["Codigo"];
                    ProdAux.MarcProducto.ID = (int)datos.Lector["IdMarca"];
                    ProdAux.MarcProducto.Descripcion = (string)datos.Lector["Descripcion"];
                    ProdAux.StockTotal = (int)datos.Lector["StockTotal"];
                    ProdAux.StockMinimo = (int)datos.Lector["StockMinimo"];
                    ProdAux.PrecioVenta = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("PrecioVenta"));
                    ProdAux.PrecioCompra = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("PrecioCompra"));

                    listaaux.Add(ProdAux);

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
