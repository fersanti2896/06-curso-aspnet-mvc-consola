// See https://aka.ms/new-console-template for more information
using AplicacionConsola;

Console.WriteLine("Hello, World!");

var insercionUsuarios = new InsercionUsuarios();
insercionUsuarios.llenado(500);

var insercionPedido = new InsercionPedido();
insercionPedido.llenado(500, 40);
