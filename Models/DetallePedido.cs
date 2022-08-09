using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class DetallePedido
    {
        public int DetallePedidoId { get; set; }
        public int Cantidad { get; set; }
        public int PedidoId { get; set; }
        public int CatProductoId { get; set; }

        public virtual CatProducto CatProducto { get; set; } = null!;
        public virtual Pedido Pedido { get; set; } = null!;
    }
}
