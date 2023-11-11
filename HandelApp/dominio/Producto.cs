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
        [DisplayName("ID Producto")]
        public int IdProducto { get; set; }

        [DisplayName("Código Producto")]
        public string Codigo { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Marca Producto")]
        public Marca Marca { get; set; }

        [DisplayName("Categoría Producto")]
        public Categoria Categoria { get; set; }

        [DisplayName("Stock Total")]
        public int StockTotal { get; set; }

        [DisplayName("Stock Mínimo")]
        public int StockMinimo { get; set; }

        [DisplayName("Precio Venta")]
        public decimal PrecioVenta { get; set; }

        [DisplayName("Precio Compra")]
        public decimal PrecioCompra { get; set; }
    }
}
