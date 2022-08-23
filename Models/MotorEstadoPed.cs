using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class MotorEstadoPed
    {
        public int MotoEstadoPedId { get; set; }
        public int CatEstadoPedidoActualId { get; set; }
        public int CatEstadoPedidoSigId { get; set; }
        public string Accion { get; set; } = null!;
        public string Icono { get; set; } = null!;
        public int CatPerfilId { get; set; }

        public virtual CatEstadoPedido CatEstadoPedidoActual { get; set; } = null!;
        public virtual CatEstadoPedido CatEstadoPedidoSig { get; set; } = null!;
        public virtual CatPerfil CatPerfil { get; set; } = null!;
    }
}
