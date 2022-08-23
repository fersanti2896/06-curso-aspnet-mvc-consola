using AplicacionConsola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola {
    public class InsercionPedido {
        public void llenado(int cantidad, int userId) {
            var numEstadosPedido = cantidadEstadosPedidos();
            var numProducto = cantidadProductos();
            var numEstadoRepublica = 32;

            for (var i = 0; i < cantidad; i++) {
                using (var modelo = new PedidosDBContext()) {
                    var _Pedido = new Pedido {
                        CatEstadoPedidoId    = Utilerias.numeroPseudoAleatorio(numEstadosPedido),
                        CatEstadoRepublicaId = Utilerias.numeroPseudoAleatorio(numEstadoRepublica),
                        FechaPedido          = DateTime.Now, 
                        UsuarioId            = userId
                    };

                    modelo.Pedidos.Add(_Pedido);
                    modelo.SaveChanges();

                    var detallePedido = new DetallePedido {
                        Cantidad = Utilerias.numeroPseudoAleatorio(10),
                        CatProductoId = Utilerias.numeroPseudoAleatorio(numProducto),
                        PedidoId = _Pedido.PedidoId
                    };

                    modelo.DetallePedidos.Add(detallePedido);
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

        private int cantidadProductos() {
            int cantidad = 0;

            using (var modelo = new PedidosDBContext()) {
                cantidad = modelo.CatProductos.Count();
            }

            return cantidad;
        }
    }
}
