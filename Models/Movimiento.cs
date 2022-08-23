using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int CatEstadoPedidoId { get; set; }
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }

        public virtual CatEstadoPedido CatEstadoPedido { get; set; } = null!;
        public virtual Pedido Pedido { get; set; } = null!;
        public virtual Usuario Usuario { get; set; } = null!;
    }
}
