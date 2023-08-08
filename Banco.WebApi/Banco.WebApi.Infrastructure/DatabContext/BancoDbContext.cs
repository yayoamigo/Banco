using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Banco.WebApi.Entity;

namespace Banco.WebApi.Infrastructure;

public partial class BancoDbContext : DbContext
{
    public BancoDbContext()
    {
    }

    public BancoDbContext(DbContextOptions<BancoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cuenta> Cuenta { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Cliente__71ABD087F54D3F3C");

            entity.ToTable("Cliente");

            entity.Property(e => e.ClienteId).ValueGeneratedNever();
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            
        });

        modelBuilder.Entity<Cuenta>(entity =>
        {
            entity.HasKey(e => e.NumeroCuenta).HasName("PK__Cuenta__E039507A14A4C2DB");

            entity.Property(e => e.NumeroCuenta).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoCuenta)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Cliente).WithMany(p => p.Cuenta)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cuenta__ClienteI__3C69FB99");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.MovimientoId).HasName("PK__Movimien__BF923C2C3B6FE0F3");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CuentaNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.NumeroCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Numer__3F466844");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PK__Persona__D6F931E4C38092D6");

            entity.ToTable("Persona");

            entity.Property(e => e.Identificacion).ValueGeneratedNever();
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
