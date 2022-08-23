using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola {
    public class Utilerias {
        public static int numeroPseudoAleatorio(int maximo) {
            dynamic cantidad = DateTime.Now.Ticks;
            cantidad = (cantidad % maximo) + 1;

            return Convert.ToInt32(cantidad);
        }
    }
}
