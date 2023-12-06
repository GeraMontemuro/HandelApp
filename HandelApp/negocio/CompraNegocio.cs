using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CompraNegocio
    {
        public List<Compra> listarconSp()
        {
            List<Compra> listaaux = new List<Compra>();
            AccesoBD datos = new AccesoBD();

            try
            {
                
                datos.setearConsulta("Select Com.ID as IDCompra, Com.Fecha, Com.IDProducto, P.Nombre as ProdNombre, Com.Cantidad, Com.PrecioCompra, Prov.NombreFantasia as NombreProv from Compras Com\r\ninner join Producto P on P.IDProducto = Com.IDProducto\r\ninner join Proveedor Prov on Prov.IDProveedor = Com.IDProveedor order by Com.Fecha asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra CompraAux = new Compra();
                    CompraAux.Producto = new Producto();
                    CompraAux.Proveedor = new Proveedor();

                    CompraAux.IDCompra = (int)datos.Lector["IDCompra"];
                    CompraAux.Fecha = (DateTime)datos.Lector["Fecha"];
                    CompraAux.Producto.IdProducto = (int)datos.Lector["IDProducto"];
                    CompraAux.Producto.Nombre = (string)datos.Lector["ProdNombre"];
                    if (!(datos.Lector["ProdNombre"] is DBNull))
                    {
                        CompraAux.Producto.Nombre = (string)datos.Lector["ProdNombre"];
                    }
                    else { CompraAux.Producto.Nombre = "No tiene"; }

                    CompraAux.Cantidad = (int)datos.Lector["Cantidad"];
                    CompraAux.PrecioCompra = datos.Lector.GetDecimal(datos.Lector.GetOrdinal("PrecioCompra"));
                    CompraAux.Proveedor.NombreFantasia = (string)datos.Lector["NombreProv"];

                    listaaux.Add(CompraAux);
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

        public Compra buscar(int ID)
        {
            Compra CompraBuscada = new Compra();
            CompraNegocio ComNeg = new CompraNegocio();
            List<Compra> ListaFiltro = new List<Compra>();
            AccesoBD accesoBD = new AccesoBD();

            try
            {
                ListaFiltro = ComNeg.listarconSp();

                foreach (var Compra in ListaFiltro)
                {
                    if (ID == (int)Compra.IDCompra)
                    {
                        CompraBuscada = Compra;
                    }
                }
                return CompraBuscada;
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

        public void alta(Compra nueva)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Compra> listaComAgregada = new List<Compra>();

            try
            {
                accesoBD.setearConsulta("INSERT INTO Compras (Fecha, IDProducto, Cantidad, PrecioCompra, IDProveedor) VALUES (@Fecha, @Producto, @Cantidad, @PrecioCompra, @Proveedor)");
                accesoBD.setearParametro("@Fecha", nueva.Fecha.ToString("yyyy-MM-dd"));
                accesoBD.setearParametro("@Producto", nueva.Producto.IdProducto);
                accesoBD.setearParametro("@Cantidad", nueva.Cantidad);
                accesoBD.setearParametro("@PrecioCompra", nueva.PrecioCompra);
                accesoBD.setearParametro("@Proveedor", nueva.Proveedor.IdProveedor);
                accesoBD.ejecutarAccion();

                listaComAgregada = listarconSp();

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


        public void modificar(Compra nueva)
        {
            AccesoBD accesoBD = new AccesoBD();
            List<Compra> listaCompraModificada = new List<Compra>();

            try
            {
                accesoBD.setearConsulta("Update Compras set Fecha = @Fecha, IDProducto = @IdProd, Cantidad = @Cantidad, PrecioCompra = @PrecioCompra, IDProveedor = @IDProveedor where ID=@id");
                accesoBD.setearParametro("@Fecha", nueva.Fecha);
                accesoBD.setearParametro("@IDProducto", nueva.Producto.IdProducto);
                accesoBD.setearParametro("@Cantidad", nueva.Cantidad);
                accesoBD.setearParametro("@PrecioCompra", nueva.PrecioCompra);
                accesoBD.setearParametro("@IDProveedor", nueva.Proveedor.IdProveedor);

                accesoBD.setearParametro("@id", nueva.IDCompra);

                accesoBD.ejecutarAccion();

                listaCompraModificada = listarconSp();
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
            AccesoBD accesoBD = new AccesoBD();
            AccesoBD accesoBD2 = new AccesoBD();
            try
            {
                Compra auxCompra = new Compra();

                auxCompra = buscar(id);

                int idProducto = auxCompra.Producto.IdProducto;
                int cantidad = auxCompra.Cantidad;
                

                accesoBD.setearConsulta("delete from Compras where ID = @id");
                accesoBD.setearParametro("@id", id);
                accesoBD.ejecutarAccion();

                accesoBD2.setearConsulta("Update Producto set StockTotal = StockTotal - @cantidad where IDProducto = @idProducto");
                accesoBD2.setearParametro("@cantidad", cantidad);
                accesoBD2.setearParametro("@idProducto", idProducto);

                accesoBD2.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoBD.cerrarConexion();
                accesoBD2.cerrarConexion();
            }
        }
    }
}
