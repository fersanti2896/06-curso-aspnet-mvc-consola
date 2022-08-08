using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime FechaPedido { get; set; }
        public int CatEstadoPedidoId { get; set; }
        public int CatEstadoRepublicaId { get; set; }

        public virtual CatEstadoPedido CatEstadoPedido { get; set; } = null!;
        public virtual CatEstadoRepublica CatEstadoRepublica { get; set; } = null!;
    }
}
