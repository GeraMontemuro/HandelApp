using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        private List<Producto> pro;
        private Producto pro1;

        public List<Producto> Cargar(int ID, List<Producto> lista, int cantidad,decimal PrecioTotal)
        {

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                pro = negocio.listarconSp();

                foreach (var Producto in pro)
                {
                    if (ID == (int)Producto.IdProducto)
                    {
                        Producto.Cantidad = cantidad;
                        Producto.PrecioFinal= PrecioTotal;  
                        lista.Add(Producto);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
        public Producto Buscar(int ID)
        {

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                pro = negocio.listarconSp();

                foreach (var Producto in pro)
                {
                    if (ID == (int)Producto.IdProducto)
                    {
                        pro1 = Producto;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return pro1;

        }
    }
}
public static class FuncionGlobal
{
    public static int Valor = 0;

    public static int CantidadTotal()
    {
        return Valor;
    }
    public static void CantidadTotalAsignada(int cont)
    {
        Valor = cont;
    }

}
