using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIWeb.DAL.Models
{
    public partial class InitialDContext : DbContext
    {
        public InitialDContext()
        {
        }

        public InitialDContext(DbContextOptions<InitialDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Concesionario> Concesionario { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<Propuesta> Propuesta { get; set; }
        public virtual DbSet<Reparacion> Reparacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=ayylosmeaos.xarblanca.es;port=3306;user=KamiKeys;password=KamiKeysDB;database=InitialD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("PRIMARY");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Dni)
                    .HasColumnName("dni")
                    .HasMaxLength(15);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Tlf)
                    .IsRequired()
                    .HasColumnName("tlf")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Concesionario>(entity =>
            {
                entity.HasKey(e => e.Direccion)
                    .HasName("PRIMARY");

                entity.ToTable("CONCESIONARIO");

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.HasKey(e => new { e.Reparacion, e.UsuarioNickUsuario })
                    .HasName("PRIMARY");

                entity.ToTable("JORNADA");

                entity.HasIndex(e => e.UsuarioNickUsuario)
                    .HasName("USUARIO_nickUsuario");

                entity.Property(e => e.Reparacion)
                    .HasColumnName("reparacion")
                    .HasMaxLength(100);

                entity.Property(e => e.UsuarioNickUsuario)
                    .HasColumnName("USUARIO_nickUsuario")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ReparacionNavigation)
                    .WithMany(p => p.Jornada)
                    .HasForeignKey(d => d.Reparacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JORNADA_ibfk_1");

                entity.HasOne(d => d.UsuarioNickUsuarioNavigation)
                    .WithMany(p => p.Jornada)
                    .HasForeignKey(d => d.UsuarioNickUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("JORNADA_ibfk_2");
            });

            modelBuilder.Entity<Propuesta>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioNickUsuario, e.VehiculoNumeroBastidor, e.ClienteDni, e.FechaInicio })
                    .HasName("PRIMARY");

                entity.ToTable("PROPUESTA");

                entity.HasIndex(e => e.ClienteDni)
                    .HasName("CLIENTE_dni");

                entity.HasIndex(e => e.VehiculoNumeroBastidor)
                    .HasName("VEHICULO_numeroBastidor");

                entity.Property(e => e.UsuarioNickUsuario)
                    .HasColumnName("USUARIO_nickUsuario")
                    .HasMaxLength(100);

                entity.Property(e => e.VehiculoNumeroBastidor)
                    .HasColumnName("VEHICULO_numeroBastidor")
                    .HasMaxLength(30);

                entity.Property(e => e.ClienteDni)
                    .HasColumnName("CLIENTE_dni")
                    .HasMaxLength(15);

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.ClienteDniNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.ClienteDni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROPUESTA_ibfk_3");

                entity.HasOne(d => d.UsuarioNickUsuarioNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.UsuarioNickUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROPUESTA_ibfk_1");

                entity.HasOne(d => d.VehiculoNumeroBastidorNavigation)
                    .WithMany(p => p.Propuesta)
                    .HasForeignKey(d => d.VehiculoNumeroBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PROPUESTA_ibfk_2");
            });

            modelBuilder.Entity<Reparacion>(entity =>
            {
                entity.HasKey(e => e.IdFactura)
                    .HasName("PRIMARY");

                entity.ToTable("REPARACION");

                entity.HasIndex(e => e.UsuarioNickUsuario)
                    .HasName("USUARIO_nickUsuario");

                entity.HasIndex(e => e.VehiculoNumeroBastidor)
                    .HasName("VEHICULO_numeroBastidor");

                entity.Property(e => e.IdFactura)
                    .HasColumnName("idFactura")
                    .HasMaxLength(100);

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasColumnName("cliente")
                    .HasMaxLength(15);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(45);

                entity.Property(e => e.FechaReparacion)
                    .HasColumnName("fechaReparacion")
                    .HasColumnType("date");

                entity.Property(e => e.Piezas)
                    .IsRequired()
                    .HasColumnName("piezas")
                    .HasMaxLength(255);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.PresupuestoEstimado).HasColumnName("presupuestoEstimado");

                entity.Property(e => e.TiempoEstimado)
                    .IsRequired()
                    .HasColumnName("tiempoEstimado")
                    .HasMaxLength(45);

                entity.Property(e => e.UsuarioNickUsuario)
                    .IsRequired()
                    .HasColumnName("USUARIO_nickUsuario")
                    .HasMaxLength(100);

                entity.Property(e => e.VehiculoNumeroBastidor)
                    .IsRequired()
                    .HasColumnName("VEHICULO_numeroBastidor")
                    .HasMaxLength(30);

                entity.HasOne(d => d.UsuarioNickUsuarioNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.UsuarioNickUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REPARACION_ibfk_1");

                entity.HasOne(d => d.VehiculoNumeroBastidorNavigation)
                    .WithMany(p => p.Reparacion)
                    .HasForeignKey(d => d.VehiculoNumeroBastidor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("REPARACION_ibfk_2");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idROL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NombreRol)
                    .IsRequired()
                    .HasColumnName("nombreRol")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PRIMARY");

                entity.ToTable("TIPO");

                entity.Property(e => e.IdTipo)
                    .HasColumnName("idTIPO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo1)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NickUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.ConcesionarioDireccion)
                    .HasName("CONCESIONARIO_direccion");

                entity.HasIndex(e => e.JefeMecanico)
                    .HasName("jefeMecanico");

                entity.HasIndex(e => e.RolIdRol)
                    .HasName("ROL_idROL");

                entity.Property(e => e.NickUsuario)
                    .HasColumnName("nickUsuario")
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(100);

                entity.Property(e => e.ConcesionarioDireccion)
                    .IsRequired()
                    .HasColumnName("CONCESIONARIO_direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasColumnName("contrasenia")
                    .HasMaxLength(100);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("dni")
                    .HasMaxLength(15);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Especialidad)
                    .HasColumnName("especialidad")
                    .HasMaxLength(100);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.JefeMecanico)
                    .HasColumnName("jefeMecanico")
                    .HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.RolIdRol)
                    .HasColumnName("ROL_idROL")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tlf)
                    .IsRequired()
                    .HasColumnName("tlf")
                    .HasMaxLength(15);

                entity.HasOne(d => d.ConcesionarioDireccionNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.ConcesionarioDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ibfk_3");

                entity.HasOne(d => d.JefeMecanicoNavigation)
                    .WithMany(p => p.InverseJefeMecanicoNavigation)
                    .HasForeignKey(d => d.JefeMecanico)
                    .HasConstraintName("USUARIO_ibfk_2");

                entity.HasOne(d => d.RolIdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolIdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_ibfk_1");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.NumeroBastidor)
                    .HasName("PRIMARY");

                entity.ToTable("VEHICULO");

                entity.HasIndex(e => e.ClienteDni)
                    .HasName("CLIENTE_dni");

                entity.HasIndex(e => e.ConcesionarioDireccion)
                    .HasName("CONCESIONARIO_direccion");

                entity.HasIndex(e => e.Matricula)
                    .HasName("matricula")
                    .IsUnique();

                entity.HasIndex(e => e.TipoIdTipo)
                    .HasName("TIPO_idTIPO");

                entity.HasIndex(e => e.UsuarioNickUsuario)
                    .HasName("USUARIO_nickUsuario");

                entity.Property(e => e.NumeroBastidor)
                    .HasColumnName("numeroBastidor")
                    .HasMaxLength(30);

                entity.Property(e => e.Anno)
                    .HasColumnName("anno")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClienteDni)
                    .HasColumnName("CLIENTE_dni")
                    .HasMaxLength(15);

                entity.Property(e => e.Combustible)
                    .IsRequired()
                    .HasColumnName("combustible")
                    .HasMaxLength(45);

                entity.Property(e => e.ConcesionarioDireccion)
                    .IsRequired()
                    .HasColumnName("CONCESIONARIO_direccion")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fechaEntrada")
                    .HasColumnType("date");

                entity.Property(e => e.FechaVenta)
                    .HasColumnName("fechaVenta")
                    .HasColumnType("date");

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasColumnType("mediumblob");

                entity.Property(e => e.Kms)
                    .HasColumnName("kms")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50);

                entity.Property(e => e.Matricula)
                    .HasColumnName("matricula")
                    .HasMaxLength(25);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("modelo")
                    .HasMaxLength(100);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.PropiedadConcesionario).HasColumnName("propiedadConcesionario");

                entity.Property(e => e.TipoIdTipo)
                    .HasColumnName("TIPO_idTIPO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioNickUsuario)
                    .HasColumnName("USUARIO_nickUsuario")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ClienteDniNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.ClienteDni)
                    .HasConstraintName("VEHICULO_ibfk_3");

                entity.HasOne(d => d.ConcesionarioDireccionNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.ConcesionarioDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VEHICULO_ibfk_1");

                entity.HasOne(d => d.TipoIdTipoNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.TipoIdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VEHICULO_ibfk_2");

                entity.HasOne(d => d.UsuarioNickUsuarioNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.UsuarioNickUsuario)
                    .HasConstraintName("VEHICULO_ibfk_4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
