using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RescateEmocional.Models;

public partial class RescateEmocionalContext : DbContext
{
    public RescateEmocionalContext()
    {
    }

    public RescateEmocionalContext(DbContextOptions<RescateEmocionalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Conversacion> Conversacions { get; set; }

    public virtual DbSet<Diario> Diarios { get; set; }

    public virtual DbSet<Etiquetum> Etiqueta { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<Organizacion> Organizacions { get; set; }

    public virtual DbSet<Peticion> Peticions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Telefono> Telefonos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdmin).HasName("PK__Administ__9BBCCA0FF990AC08");

            entity.ToTable("Administrador");

            entity.Property(e => e.IdAdmin).HasColumnName("ID_admin");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Administr__ID_ro__403A8C7D");
        });

        modelBuilder.Entity<Conversacion>(entity =>
        {
            entity.HasKey(e => e.IdConversacion).HasName("PK__Conversa__183A6D200803F505");

            entity.ToTable("Conversacion");

            entity.Property(e => e.IdConversacion).HasColumnName("ID_conversacion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_inicio");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Conversacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Conversac__ID_us__4F7CD00D");
        });

        modelBuilder.Entity<Diario>(entity =>
        {
            entity.HasKey(e => e.IdDiario).HasName("PK__Diario__BDEDF28C88E4B781");

            entity.ToTable("Diario");

            entity.Property(e => e.IdDiario).HasColumnName("ID_diario");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_hora");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Diarios)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Diario__ID_usuar__4CA06362");
        });

        modelBuilder.Entity<Etiquetum>(entity =>
        {
            entity.HasKey(e => e.IdEtiqueta).HasName("PK__Etiqueta__FCF76051807ACE79");

            entity.Property(e => e.IdEtiqueta).HasColumnName("ID_etiqueta");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.IdMensaje).HasName("PK__Mensaje__70A3C0B3FF8F90E6");

            entity.ToTable("Mensaje");

            entity.Property(e => e.IdMensaje).HasColumnName("ID_mensaje");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_hora");
            entity.Property(e => e.IdConversacion).HasColumnName("ID_conversacion");

            entity.HasOne(d => d.IdConversacionNavigation).WithMany(p => p.Mensajes)
                .HasForeignKey(d => d.IdConversacion)
                .HasConstraintName("FK__Mensaje__ID_conv__52593CB8");
        });

        modelBuilder.Entity<Organizacion>(entity =>
        {
            entity.HasKey(e => e.IdOrganizacion).HasName("PK__Organiza__B379590F6AAFE738");

            entity.ToTable("Organizacion");

            entity.Property(e => e.IdOrganizacion).HasColumnName("ID_organizacion");
            entity.Property(e => e.Horario).HasMaxLength(50);
            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Ubicacion).HasMaxLength(255);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Organizacions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Organizac__ID_ro__398D8EEE");

            entity.HasMany(d => d.IdEtiqueta).WithMany(p => p.IdOrganizacions)
                .UsingEntity<Dictionary<string, object>>(
                    "OrganizacionEtiquetum",
                    r => r.HasOne<Etiquetum>().WithMany()
                        .HasForeignKey("IdEtiqueta")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Organizac__ID_et__5812160E"),
                    l => l.HasOne<Organizacion>().WithMany()
                        .HasForeignKey("IdOrganizacion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Organizac__ID_or__571DF1D5"),
                    j =>
                    {
                        j.HasKey("IdOrganizacion", "IdEtiqueta").HasName("PK__Organiza__BCB62F0ADF15D23C");
                        j.ToTable("OrganizacionEtiqueta");
                        j.IndexerProperty<int>("IdOrganizacion").HasColumnName("ID_organizacion");
                        j.IndexerProperty<int>("IdEtiqueta").HasColumnName("ID_etiqueta");
                    });
        });

        modelBuilder.Entity<Peticion>(entity =>
        {
            entity.HasKey(e => e.IdPeticion).HasName("PK__Peticion__D606F3F53E98A065");

            entity.ToTable("Peticion");

            entity.Property(e => e.IdPeticion).HasColumnName("ID_peticion");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_solicitud");
            entity.Property(e => e.IdAdmin).HasColumnName("ID_admin");
            entity.Property(e => e.IdOrganizacion).HasColumnName("ID_organizacion");

            entity.HasOne(d => d.IdAdminNavigation).WithMany(p => p.Peticions)
                .HasForeignKey(d => d.IdAdmin)
                .HasConstraintName("FK__Peticion__ID_adm__49C3F6B7");

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.Peticions)
                .HasForeignKey(d => d.IdOrganizacion)
                .HasConstraintName("FK__Peticion__ID_org__48CFD27E");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__182A541252035F11");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Telefono>(entity =>
        {
            entity.HasKey(e => e.IdTelefono).HasName("PK__Telefono__5FDBA2A5A43ABC24");

            entity.ToTable("Telefono");

            entity.Property(e => e.IdTelefono).HasColumnName("ID_telefono");
            entity.Property(e => e.Estado).HasMaxLength(20);
            entity.Property(e => e.IdOrganizacion).HasColumnName("ID_organizacion");
            entity.Property(e => e.Numero).HasMaxLength(15);
            entity.Property(e => e.TipoDeNumero)
                .HasMaxLength(20)
                .HasColumnName("Tipo_de_numero");

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.Telefonos)
                .HasForeignKey(d => d.IdOrganizacion)
                .HasConstraintName("FK__Telefono__ID_org__3D5E1FD2");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DF3D42520B109706");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_usuario");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("Correo_electronico");
            entity.Property(e => e.Estado).HasMaxLength(10);
            entity.Property(e => e.IdOrganizacion).HasColumnName("ID_organizacion");
            entity.Property(e => e.IdRol).HasColumnName("ID_rol");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.IdOrganizacionNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdOrganizacion)
                .HasConstraintName("FK__Usuario__ID_orga__440B1D61");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__ID_rol__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
