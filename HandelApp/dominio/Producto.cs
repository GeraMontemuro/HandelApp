using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        [DisplayName("Código Producto")]
        public long Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Marca Producto")]
        public Marca Marca { get; set; }

        [DisplayName("Categoría Producto")]
        public Categoria Categoria { get; set; }
        public long StockTotal { get; set; }
        [DisplayName("Stock Mínimo")]
        public byte StockMinimo { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
    }
}
