using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatEstadoPedido
    {
        public CatEstadoPedido()
        {
            MotorEstadoPedCatEstadoPedidoActuals = new HashSet<MotorEstadoPed>();
            MotorEstadoPedCatEstadoPedidoSigs = new HashSet<MotorEstadoPed>();
            Movimientos = new HashSet<Movimiento>();
            Pedidos = new HashSet<Pedido>();
        }

        public int CatEstadoPedidoId { get; set; }
        public string Concepto { get; set; } = null!;

        public virtual ICollection<MotorEstadoPed> MotorEstadoPedCatEstadoPedidoActuals { get; set; }
        public virtual ICollection<MotorEstadoPed> MotorEstadoPedCatEstadoPedidoSigs { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
