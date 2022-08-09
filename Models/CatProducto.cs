using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatProducto
    {
        public CatProducto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int CatProductoId { get; set; }
        public string Concepto { get; set; } = null!;

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
