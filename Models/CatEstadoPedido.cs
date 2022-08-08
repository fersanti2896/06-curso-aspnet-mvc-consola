using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatEstadoPedido
    {
        public CatEstadoPedido()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int CatEstadoPedidoId { get; set; }
        public string Concepto { get; set; } = null!;

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
