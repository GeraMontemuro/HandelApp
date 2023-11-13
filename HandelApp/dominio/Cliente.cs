using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public long IdCliente { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuil { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
    }
}
