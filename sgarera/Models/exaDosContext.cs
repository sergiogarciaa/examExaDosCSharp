using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sgarera.Models
{
    public partial class exaDosContext : DbContext
    {
        public exaDosContext()
        {
        }

        public exaDosContext(DbContextOptions<exaDosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reserva> Reservas { get; set; } = null!;
        public virtual DbSet<Reserva1> Reservas1 { get; set; } = null!;
        public virtual DbSet<Vajilla> Vajillas { get; set; } = null!;
        public virtual DbSet<Vajilla1> Vajillas1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("name=CadenaConexionPostgreSQL");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Idreserva)
                    .HasName("reservas_pkey");

                entity.ToTable("reservas");

                entity.Property(e => e.Idreserva).HasColumnName("idreserva");

                entity.Property(e => e.Fchreserva)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fchreserva");

                entity.Property(e => e.Idvajres).HasColumnName("idvajres");
            });

            modelBuilder.Entity<Reserva1>(entity =>
            {
                entity.HasKey(e => e.Idreserva)
                    .HasName("reservas_pkey");

                entity.ToTable("reservas", "esqexados");

                entity.Property(e => e.Idreserva)
                    .HasColumnName("idreserva")
                    .HasDefaultValueSql("nextval('reservas_idreserva_seq'::regclass)");

                entity.Property(e => e.Fchreserva)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("fchreserva");
            });

            modelBuilder.Entity<Vajilla>(entity =>
            {
                entity.HasKey(e => e.Idelemento)
                    .HasName("vajillas_pkey");

                entity.ToTable("vajillas", "esqexados");

                entity.Property(e => e.Idelemento)
                    .HasColumnName("idelemento")
                    .HasDefaultValueSql("nextval('vajillas_idelemento_seq'::regclass)");

                entity.Property(e => e.Cantidadelemento).HasColumnName("cantidadelemento");

                entity.Property(e => e.Codigoelemento)
                    .HasMaxLength(255)
                    .HasColumnName("codigoelemento");

                entity.Property(e => e.Descripcionelemento)
                    .HasMaxLength(255)
                    .HasColumnName("descripcionelemento");

                entity.Property(e => e.Nombreelemento)
                    .HasMaxLength(255)
                    .HasColumnName("nombreelemento");
            });

            modelBuilder.Entity<Vajilla1>(entity =>
            {
                entity.HasKey(e => e.Idelemento)
                    .HasName("vajillas_pkey");

                entity.ToTable("vajillas");

                entity.Property(e => e.Idelemento).HasColumnName("idelemento");

                entity.Property(e => e.Cantidadelemento).HasColumnName("cantidadelemento");

                entity.Property(e => e.Codigoelemento)
                    .HasMaxLength(255)
                    .HasColumnName("codigoelemento");

                entity.Property(e => e.Descripcionelemento)
                    .HasMaxLength(255)
                    .HasColumnName("descripcionelemento");

                entity.Property(e => e.Idvajres).HasColumnName("idvajres");

                entity.Property(e => e.Nombreelemento)
                    .HasMaxLength(255)
                    .HasColumnName("nombreelemento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
