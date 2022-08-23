using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplicacionConsola.Models
{
    public partial class PedidosDBContext : DbContext
    {
        public PedidosDBContext()
        {
        }

        public PedidosDBContext(DbContextOptions<PedidosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatEstadoPedido> CatEstadoPedidos { get; set; } = null!;
        public virtual DbSet<CatEstadoRepublica> CatEstadoRepublicas { get; set; } = null!;
        public virtual DbSet<CatPerfil> CatPerfils { get; set; } = null!;
        public virtual DbSet<CatProducto> CatProductos { get; set; } = null!;
        public virtual DbSet<CatRegion> CatRegions { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<MotorEstadoPed> MotorEstadoPeds { get; set; } = null!;
        public virtual DbSet<Movimiento> Movimientos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SOC29001S5QP8; Database=PedidosDB; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatEstadoPedido>(entity =>
            {
                entity.ToTable("CatEstadoPedido");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatEstadoRepublica>(entity =>
            {
                entity.ToTable("CatEstadoRepublica");

                entity.HasIndex(e => e.CatRegionId, "IX_CatEstadoRepublica_CatRegionId");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CatRegion)
                    .WithMany(p => p.CatEstadoRepublicas)
                    .HasForeignKey(d => d.CatRegionId);
            });

            modelBuilder.Entity<CatPerfil>(entity =>
            {
                entity.HasKey(e => e.CatPerfiId);

                entity.ToTable("CatPerfil");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatProducto>(entity =>
            {
                entity.ToTable("CatProducto");

                entity.Property(e => e.Concepto)
                    .HasMaxLength(33)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatRegion>(entity =>
            {
                entity.ToTable("CatRegion");

                entity.Property(e => e.NombreRegion)
                    .HasMaxLength(22)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.ToTable("DetallePedido");

                entity.HasIndex(e => e.CatProductoId, "IX_DetallePedido_CatProductoId");

                entity.HasIndex(e => e.PedidoId, "IX_DetallePedido_PedidoId");

                entity.HasOne(d => d.CatProducto)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.CatProductoId);

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.PedidoId);
            });

            modelBuilder.Entity<MotorEstadoPed>(entity =>
            {
                entity.HasKey(e => e.MotoEstadoPedId);

                entity.ToTable("MotorEstadoPed");

                entity.HasIndex(e => e.CatEstadoPedidoActualId, "IX_MotorEstadoPed_CatEstadoPedidoActualId");

                entity.HasIndex(e => e.CatEstadoPedidoSigId, "IX_MotorEstadoPed_CatEstadoPedidoSigId");

                entity.HasIndex(e => e.CatPerfilId, "IX_MotorEstadoPed_CatPerfilId");

                entity.Property(e => e.Accion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Icono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CatEstadoPedidoActual)
                    .WithMany(p => p.MotorEstadoPedCatEstadoPedidoActuals)
                    .HasForeignKey(d => d.CatEstadoPedidoActualId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CatEstadoPedidoSig)
                    .WithMany(p => p.MotorEstadoPedCatEstadoPedidoSigs)
                    .HasForeignKey(d => d.CatEstadoPedidoSigId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.CatPerfil)
                    .WithMany(p => p.MotorEstadoPeds)
                    .HasForeignKey(d => d.CatPerfilId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.ToTable("Movimiento");

                entity.HasIndex(e => e.CatEstadoPedidoId, "IX_Movimiento_CatEstadoPedidoId");

                entity.HasIndex(e => e.PedidoId, "IX_Movimiento_PedidoId");

                entity.HasIndex(e => e.UsuarioId, "IX_Movimiento_UsuarioId");

                entity.HasOne(d => d.CatEstadoPedido)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CatEstadoPedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.HasIndex(e => e.CatEstadoPedidoId, "IX_Pedido_CatEstadoPedidoId");

                entity.HasIndex(e => e.CatEstadoRepublicaId, "IX_Pedido_CatEstadoRepublicaId");

                entity.HasIndex(e => e.UsuarioId, "IX_Pedido_UsuarioId");

                entity.HasOne(d => d.CatEstadoPedido)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CatEstadoPedidoId);

                entity.HasOne(d => d.CatEstadoRepublica)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CatEstadoRepublicaId);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.UsuarioId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.CatEstadoRepublicaId, "IX_Usuario_CatEstadoRepublicaId");

                entity.HasIndex(e => e.CatPerfilId, "IX_Usuario_CatPerfilId");

                entity.HasIndex(e => e.CatRegionId, "IX_Usuario_CatRegionId");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.CatEstadoRepublica)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CatEstadoRepublicaId);

                entity.HasOne(d => d.CatPerfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CatPerfilId);

                entity.HasOne(d => d.CatRegion)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CatRegionId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
