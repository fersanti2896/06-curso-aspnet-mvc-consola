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
        public virtual DbSet<CatProducto> CatProductos { get; set; } = null!;
        public virtual DbSet<CatRegion> CatRegions { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;

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

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido");

                entity.HasIndex(e => e.CatEstadoPedidoId, "IX_Pedido_CatEstadoPedidoId");

                entity.HasIndex(e => e.CatEstadoRepublicaId, "IX_Pedido_CatEstadoRepublicaId");

                entity.HasOne(d => d.CatEstadoPedido)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CatEstadoPedidoId);

                entity.HasOne(d => d.CatEstadoRepublica)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CatEstadoRepublicaId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
