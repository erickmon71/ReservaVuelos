using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservaVuelos.Models;

public partial class TravelBookingDbContext : DbContext
{
    public TravelBookingDbContext()
    {
    }

    public TravelBookingDbContext(DbContextOptions<TravelBookingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PreferenciasUsuario> PreferenciasUsuarios { get; set; }

    public virtual DbSet<Reservacione> Reservaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PreferenciasUsuario>(entity =>
        {
            entity.HasKey(e => e.PreferenciaId).HasName("PK__Preferen__90643E41A8F46704");

            entity.ToTable("PreferenciasUsuario");

            entity.Property(e => e.Preferencia).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithMany(p => p.PreferenciasUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Preferenc__Usuar__5441852A");
        });

        modelBuilder.Entity<Reservacione>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservac__C399376353650213");

            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PrecioTotal).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Reservaci__Usuar__4F7CD00D");

            entity.HasOne(d => d.Vuelo).WithMany(p => p.Reservaciones)
                .HasForeignKey(d => d.VueloId)
                .HasConstraintName("FK__Reservaci__Vuelo__5070F446");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B81A45F970");

            entity.HasIndex(e => e.Correo, "UQ__Usuarios__60695A192C20E2B7").IsUnique();

            entity.Property(e => e.Clave).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.VueloId).HasName("PK__Vuelos__990F079AA7B53967");

            entity.Property(e => e.Aerolinea).HasMaxLength(100);
            entity.Property(e => e.CiudadLlegada).HasMaxLength(100);
            entity.Property(e => e.CiudadSalida).HasMaxLength(100);
            entity.Property(e => e.FechaLlegada).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
