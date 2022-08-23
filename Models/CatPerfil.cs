using System;
using System.Collections.Generic;

namespace AplicacionConsola.Models
{
    public partial class CatPerfil
    {
        public CatPerfil()
        {
            MotorEstadoPeds = new HashSet<MotorEstadoPed>();
            Usuarios = new HashSet<Usuario>();
        }

        public int CatPerfiId { get; set; }
        public string Concepto { get; set; } = null!;

        public virtual ICollection<MotorEstadoPed> MotorEstadoPeds { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
