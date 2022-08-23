using AplicacionConsola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionConsola {
    public class InsercionUsuarios {
        List<string> NombreHombres = new List<string>();
        List<string> NombreMujeres = new List<string>();
        List<string> NombreApellidos = new List<string>();

        public void llenado(int totalRegistros) {
            InicializacionListados();

            var numeroNombresHombres  = NombreHombres.Count;
            var numeroNombreMujeres   = NombreMujeres.Count;
            var numeroNombreApellidos = NombreApellidos.Count;

            for (int i = 0; i < totalRegistros; i++) {
                var momento  = DateTime.Now.Ticks;
                var esHombre = momento % 2 == 0;
                var nombre   = "";
                var apellido = "";
                var numero   = 0;

                if (esHombre) {
                    numero = Utilerias.numeroPseudoAleatorio(numeroNombresHombres);
                    nombre = NombreHombres[numero - 1];
                } else {
                    numero = Utilerias.numeroPseudoAleatorio(numeroNombreMujeres);
                    nombre = NombreMujeres[numero - 1];
                }

                numero = Utilerias.numeroPseudoAleatorio(numeroNombreApellidos);
                apellido = NombreApellidos[numero - 1];

                nombre = nombre.Trim() + " " + apellido.Trim();

                using var context = new PedidosDBContext();
                /* Evaluamos si existe el usuario con ese nombre */
                var existe = (from a in context.Usuarios
                              where a.Name == nombre
                              select a).Any();

                if (!existe) {
                    int? CatRegionId = null, CatEstadoRepublicaId = null;
                    int CatPerfilId = 0;

                    momento = DateTime.Now.Ticks;
                    var decision = momento % 3;

                    switch (decision) {
                        /* Inserta Usuario con Perfil Gerente Regional */
                        case 0:
                            CatRegionId = Utilerias.numeroPseudoAleatorio(5);
                            CatPerfilId = 4;
                            break;
                        /* Perfil: Reparto o Captura, Gerencia Estatal */
                        case 1:
                            CatEstadoRepublicaId = Utilerias.numeroPseudoAleatorio(32);
                            CatPerfilId = Utilerias.numeroPseudoAleatorio(3);
                            break;
                        /* No tiene asociado CatRegion y CatRepublica | Perfil: Vicepresidencia*/
                        case 2:
                            CatPerfilId = 5;
                            break;
                    }

                    var aux = nombre.Substring(0, 5);
                    var pwd = aux + Utilerias.numeroPseudoAleatorio(9) + Utilerias.numeroPseudoAleatorio(9);

                    string username = ObtenerUserName(nombre, context);

                    var _Usuario = new Usuario {
                        CatEstadoRepublicaId = CatEstadoRepublicaId,
                        CatRegionId = CatRegionId,
                        UserName = username,
                        Name = nombre,
                        CatPerfilId = CatPerfilId,
                        Password = pwd
                    };

                    context.Usuarios.Add(_Usuario);
                    context.SaveChanges();
                }
            }
        }

        private void InicializacionListados() {
            var directorio = @"C:\CU";
            var file = System.IO.Path.Combine(directorio, "NombreHombres.txt");
            NombreHombres = System.IO.File.ReadAllLines(file).ToList();

            var file2 = System.IO.Path.Combine(directorio, "NombreMujeres.txt");
            NombreMujeres = System.IO.File.ReadAllLines(file2).ToList();

            var file3 = System.IO.Path.Combine(directorio, "NombreApellidos.txt");
            NombreApellidos = System.IO.File.ReadAllLines(file3).ToList();
        }

        private string ObtenerUserName(string nombre, PedidosDBContext context) {
            bool _existe = false;
            var username = nombre.Length < 15 ? nombre : nombre.Substring(0, 15);

            username = username.Replace(" ", "_");
            var user = username;

            var indice = 0;

            while (true) {
                _existe = context.Usuarios.Where(s => s.UserName == username).Any();

                if (_existe) {
                    user = user + (++indice);
                } else {
                    break;
                }
            }

            return username;
        }
    }
}
