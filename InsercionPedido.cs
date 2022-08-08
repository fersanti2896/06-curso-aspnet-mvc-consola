using AplicacionConsola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola {
    public class InsercionPedido {
        public void llenado(int cantidad) {
            var numEstadosPedido = cantidadEstadosPedidos();
            var numEstadoRepublica = 32;

            for (var i = 0; i < cantidad; i++) {
                using (var modelo = new PedidosDBContext()) {
                    var _Pedido = new Pedido {
                        CatEstadoPedidoId = numeroPseudoAleatorio(numEstadosPedido),
                        CatEstadoRepublicaId = numeroPseudoAleatorio(numEstadoRepublica),
                        FechaPedido = DateTime.Now
                    };

                    modelo.Pedidos.Add(_Pedido);
                    modelo.SaveChanges();
                }
            }
        }

        private int cantidadEstadosPedidos() {
            int cantidad = 0;
            using (var modelo = new PedidosDBContext()) {
                cantidad = modelo.CatEstadoPedidos.Count();
            }

            return cantidad;
        }

        private int numeroPseudoAleatorio(int maximo) {
            dynamic cantidad = DateTime.Now.Ticks;
            cantidad = (cantidad % maximo) + 1;

            return Convert.ToInt32(cantidad);
        }
    }
}
