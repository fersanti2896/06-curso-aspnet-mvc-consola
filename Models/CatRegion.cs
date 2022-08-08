using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatRegion
    {
        public CatRegion()
        {
            CatEstadoRepublicas = new HashSet<CatEstadoRepublica>();
        }

        public int CatRegionId { get; set; }
        public string NombreRegion { get; set; } = null!;

        public virtual ICollection<CatEstadoRepublica> CatEstadoRepublicas { get; set; }
    }
}
