using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int IDVenta { get; set; }
        public List<Producto> ProductoVenta { get; set; }
        public Cliente ClienteVenta { get; set; }
        public Usuario UsuarioVenta { get; set; }
        public decimal TotalVenta { get; set; }
    }
}
