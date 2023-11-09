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
        public int Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca MarcProducto { get; set; }
        [DisplayName("Categoría Producto")]
        public Categoria CatProducto { get; set; }
        public int StockTotal { get; set; }
        [DisplayName("Stock Mínimo")]
        public int StockMinimo { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioCompra { get; set; }
    }
}
