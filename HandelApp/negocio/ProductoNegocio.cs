using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Data;
using System.Reflection;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.Design;
using System.Collections;

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
                datos.setearConsulta("select P.Codigo, P.Nombre, P.Descripcion, P.Marcas, M.Descripcion as MDes, P.Categorias, C.Descripcion as CDes, P.StockTotal, P.StockMinimo, \r\nP.PrecioVenta, P.PrecioCompra from Producto P \r\ninner join Marcas M on M.IDMarca = P.Marcas\r\ninner join Categorias C on C.IDCategoria = P.Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read()){

                    Producto ProdAux = new Producto();
                    ProdAux.Marca = new Marca();
                    ProdAux.Categoria = new Categoria();

                    //ProdAux.IdProducto = (int)datos.Lector["IdProducto"];
                    ProdAux.Codigo = (string)datos.Lector["Codigo"];
                    ProdAux.Nombre = (string)datos.Lector["Nombre"];
                    ProdAux.Descripcion = (string)datos.Lector["Descripcion"];
                    ProdAux.Marca.ID= (int)datos.Lector["Marcas"];
                    if (!(datos.Lector["Marcas"] is DBNull))
                    {
                        ProdAux.Marca.Descripcion = (string)datos.Lector["MDes"];
                    }
                    else { ProdAux.Marca.Descripcion = "No tiene"; }
                    ProdAux.Categoria.Id = (int)datos.Lector["Categorias"];
                    if (!(datos.Lector["Categorias"] is DBNull))
                    {
                        ProdAux.Categoria.Descripcion = (string)datos.Lector["CDes"];
                    }
                    else { ProdAux.Categoria.Descripcion = "No tiene"; }
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
