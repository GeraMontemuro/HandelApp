using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Compra
    {
        [DisplayName("Id Compra")]
        public int IDCompra { get; set; }

        [DisplayName("Fecha")]
        public DateTime Fecha { get; set; }

        [DisplayName("Producto")]
        public Producto Producto { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [DisplayName("PU Compra")]
        public decimal PrecioCompra { get; set; }

        [DisplayName("Proveedor")]
        public Proveedor Proveedor { get; set; }
    }
}
