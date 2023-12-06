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
                datos.setearConsulta("select P.IDProducto, P.Codigo, P.Nombre, P.Descripcion, P.Marcas, M.Descripcion as MDes, P.Categorias, C.Descripcion as CDes, P.StockTotal,P.Porcentaje, P.StockMinimo, \r\n P.PrecioCompra from Producto P \r\ninner join Marcas M on M.IDMarca = P.Marcas\r\ninner join Categorias C on C.IDCategoria = P.Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read()){

                    Producto ProdAux = new Producto();
                    ProdAux.Marca = new Marca();
                    ProdAux.Categoria = new Categoria();

                    ProdAux.IdProducto = (int)datos.Lector["IDProducto"];
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
                    ProdAux.PrecioCompra = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("PrecioCompra"));
                    ProdAux.PorcentajeGanancia = (decimal)datos.Lector["Porcentaje"];
                    ProdAux.CalcularPRecioVenta();

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
            Producto ProductoBuscado=new Producto();
            ProductoNegocio Pnego = new ProductoNegocio();  
            List<Producto> ListaFiltro = new List<Producto>();   
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                ListaFiltro = Pnego.listarconSp();

                foreach(var Producto in ListaFiltro)
                {
                    if(ID== (int)Producto.IdProducto)
                    {
                        ProductoBuscado=Producto;
                    }
                }

                return ProductoBuscado;
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


        public void alta(Producto nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Producto> listaProdAgregado = new List<Producto>();

            try
            {
                accesoBD.setearConsulta("insert Into Producto (Nombre, Descripcion, Codigo, Marcas, Categorias, StockTotal, StockMinimo, PrecioCompra, Porcentaje) values ('" + nuevo.Nombre + "', '" + nuevo.Descripcion + "','" + nuevo.Codigo + "', @Marcas, @Categorias,'" + nuevo.StockTotal + "','" + nuevo.StockMinimo + "','" + nuevo.PrecioCompra + "','" + nuevo.PorcentajeGanancia + "')");
                accesoBD.setearParametro("@Marcas", nuevo.Marca.ID);
                accesoBD.setearParametro("@Categorias", nuevo.Categoria.Id);
                accesoBD.ejecutarAccion();

                listaProdAgregado = listarconSp();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoBD.cerrarConexion();
            }
        }


        public void modificar(Producto nuevo)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Producto> listaProdmodificado = new List<Producto>();

            try
            {
                accesoBD.setearConsulta("Update Producto set Nombre = @Nombre,Descripcion = @Descripcion,StockMinimo = @StockMinimo, StockTotal = @StockTotal, PrecioCompra = @PrecioCompra, Porcentaje = @Porcentaje where IDProducto=@id");
                accesoBD.setearParametro("@Nombre", nuevo.Nombre);
                accesoBD.setearParametro("@Descripcion", nuevo.Descripcion);
                accesoBD.setearParametro("@StockMinimo", nuevo.StockMinimo);
                accesoBD.setearParametro("@StockTotal", nuevo.StockTotal);
                accesoBD.setearParametro("@PrecioCompra", nuevo.PrecioCompra);
                accesoBD.setearParametro("@Porcentaje", nuevo.PorcentajeGanancia);
                accesoBD.setearParametro("@id", nuevo.IdProducto);

                accesoBD.ejecutarAccion();

                listaProdmodificado = listarconSp();
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

        public void baja(int id)
        {
            try
            {
                AccesoBD accesoBD = new AccesoBD();

                accesoBD.setearConsulta("delete from Producto where IdProducto = @id");
                accesoBD.setearParametro("@id", id);
                accesoBD.ejecutarAccion();

                accesoBD.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cargarStock(int idProducto, int cantidad, decimal precio)
        {
            Producto producto = new Producto();


            producto = buscar(idProducto);

            if (producto != null)
            {
                producto.StockTotal += cantidad;
                producto.PrecioCompra = precio;

                modificar(producto);
            }
        }
        public void modificarStock(int idProducto, int cantidad)
        {
            AccesoBD accesoBD2 = new AccesoBD();

            accesoBD2.setearConsulta("Update Producto set StockTotal = StockTotal - @cantidad where IDProducto = @idProducto");
            accesoBD2.setearParametro("@cantidad", cantidad);
            accesoBD2.setearParametro("@idProducto", idProducto);

            accesoBD2.ejecutarAccion();
            accesoBD2.cerrarConexion();
        }
    }
}
