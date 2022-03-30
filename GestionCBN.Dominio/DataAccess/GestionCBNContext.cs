using System;
using GestionCBN.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestionCBN.Dominio.DataAccess

{
    public partial class GestionCBNContext : DbContext
    {
        public GestionCBNContext()
        {
        }

        public GestionCBNContext(DbContextOptions<GestionCBNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Escuela> Escuelas { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Jornadum> Jornada { get; set; }
        public virtual DbSet<Modalidad> Modalidads { get; set; }
        public virtual DbSet<Programa> Programas { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC-02-SALA7;Initial Catalog=GestionCBN;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Escuela>(entity =>
            {
                entity.ToTable("Escuela");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.ToTable("EstadoCivil");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("Estudiante");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.CorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Nombre2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.HasOne(d => d.FkEstadoCivilNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.FkEstadoCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_EstadoCivil");

                entity.HasOne(d => d.FkTipoDocumentoNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.FkTipoDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiante_TipoDocumento");
            });

            modelBuilder.Entity<Jornadum>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(10);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Modalidad>(entity =>
            {
                entity.ToTable("Modalidad");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.ToTable("Programa");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.DescuentoProntoPago).HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkJornada)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkEscuelaNavigation)
                    .WithMany(p => p.Programas)
                    .HasForeignKey(d => d.FkEscuela)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programa_Escuela");

                entity.HasOne(d => d.FkJornadaNavigation)
                    .WithMany(p => p.Programas)
                    .HasForeignKey(d => d.FkJornada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programa_Jornada");

                entity.HasOne(d => d.FkModalidadNavigation)
                    .WithMany(p => p.Programas)
                    .HasForeignKey(d => d.FkModalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Programa_Modalidad");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.ToTable("TipoDocumento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Siglas)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
