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
                //datos.setearProcedimiento("SP_listarProducto");
                datos.setearConsulta("select Codigo as NCodigo, Marcas as N_Marca, Categorias as N_Categoria, StockTotal as Stock, StockMinimo as N_stockMi, PrecioVenta as Precio, PrecioCompra as N_PrecioCompra, Descripcion from Producto");
                datos.ejecutarLectura();

                while (datos.Lector.Read()){

                    Producto ProdAux = new Producto();
                    ProdAux.MarcProducto = new Marca();
                    ProdAux.CatProducto = new Categoria();

                    ProdAux.Codigo = (int)datos.Lector["NCodigo"];
                    ProdAux.MarcProducto.ID= (int)datos.Lector["N_Marcas"];
                    ProdAux.CatProducto.Id = (int)datos.Lector["N_Categorias"];
                    ProdAux.StockTotal = (int)datos.Lector["Stock"];
                   // ProdAux.StockMinimo = (int)datos.Lector["StockMinimo"];
                    ProdAux.PrecioVenta = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("Precio"));
                    ProdAux.PrecioCompra = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("N_PrecioCompra"));
                    ProdAux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public Producto buscar(int ID)
        {
            Producto TT=new Producto();
            return TT;
        }


        public void alta(Producto nuevo)
        {
            /// ventana de carga de producto, guardo en un objeto producto del back y llamo a la funcion en el onclick de aceptar
        }


        public void modificar(Producto nuevo)
        {
            /// selecciono el row o el id del dgv 
        }

        public void baja(Producto nuevo)
        {
            /// ver si usamos baja fisica o logica.
        }
    }
}
