using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Movimientos = new HashSet<Movimiento>();
            Pedidos = new HashSet<Pedido>();
        }

        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int CatPerfilId { get; set; }
        public int? CatRegionId { get; set; }
        public int? CatEstadoRepublicaId { get; set; }

        public virtual CatEstadoRepublica? CatEstadoRepublica { get; set; }
        public virtual CatPerfil CatPerfil { get; set; } = null!;
        public virtual CatRegion? CatRegion { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
