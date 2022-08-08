using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatEstadoRepublica
    {
        public CatEstadoRepublica()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int CatEstadoRepublicaId { get; set; }
        public string Sigla { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public int CatRegionId { get; set; }

        public virtual CatRegion CatRegion { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
