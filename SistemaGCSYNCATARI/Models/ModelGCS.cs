using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaGCSYNCATARI.Models
{
    public partial class ModelGCS : DbContext
    {
        public ModelGCS()
            : base("name=ModelGCS")
        {
        }

        public virtual DbSet<Cronograma> Cronograma { get; set; }
        public virtual DbSet<Cronograma_elemento_configuracion> Cronograma_elemento_configuracion { get; set; }
        public virtual DbSet<Cronograma_Fase> Cronograma_Fase { get; set; }
        public virtual DbSet<Detalle_Informe> Detalle_Informe { get; set; }
        public virtual DbSet<Elemento_Configuracion> Elemento_Configuracion { get; set; }
        public virtual DbSet<Fase> Fase { get; set; }
        public virtual DbSet<Informe_Cambio> Informe_Cambio { get; set; }
        public virtual DbSet<Metodologia> Metodologia { get; set; }
        public virtual DbSet<Miembro_Proyecto> Miembro_Proyecto { get; set; }
        public virtual DbSet<Orden_Cambio> Orden_Cambio { get; set; }
        public virtual DbSet<Orden_Cambio_Detalle> Orden_Cambio_Detalle { get; set; }
        public virtual DbSet<Pantilla_elemento_configuracion> Pantilla_elemento_configuracion { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Solicitud_Cambios> Solicitud_Cambios { get; set; }
        public virtual DbSet<Tarea_ECS> Tarea_ECS { get; set; }
        public virtual DbSet<Tipo_Usuario> Tipo_Usuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Version_ECS> Version_ECS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cronograma>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Cronograma>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Cronograma>()
                .HasMany(e => e.Cronograma_Fase)
                .WithRequired(e => e.Cronograma)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cronograma_elemento_configuracion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cronograma_elemento_configuracion>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Cronograma_Fase>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cronograma_Fase>()
                .HasMany(e => e.Cronograma_elemento_configuracion)
                .WithRequired(e => e.Cronograma_Fase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Detalle_Informe>()
                .Property(e => e.Tiempo)
                .IsUnicode(false);

            modelBuilder.Entity<Detalle_Informe>()
                .Property(e => e.Costo)
                .IsUnicode(false);

            modelBuilder.Entity<Detalle_Informe>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .HasMany(e => e.Pantilla_elemento_configuracion)
                .WithRequired(e => e.Elemento_Configuracion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Elemento_Configuracion>()
                .HasMany(e => e.Version_ECS)
                .WithRequired(e => e.Elemento_Configuracion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fase>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Fase>()
                .HasMany(e => e.Pantilla_elemento_configuracion)
                .WithRequired(e => e.Fase)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.Tiempo)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.CostoEconomico)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.ImpactoProblema)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Informe_Cambio>()
                .HasMany(e => e.Detalle_Informe)
                .WithRequired(e => e.Informe_Cambio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Metodologia>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Metodologia>()
                .HasMany(e => e.Fase)
                .WithRequired(e => e.Metodologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Metodologia>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Metodologia)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Solicitud_Cambios)
                .WithRequired(e => e.Miembro_Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Miembro_Proyecto>()
                .HasMany(e => e.Version_ECS)
                .WithRequired(e => e.Miembro_Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.FechaAprobacion)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.Descripción)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.PorcentajeAvance)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio>()
                .HasMany(e => e.Orden_Cambio_Detalle)
                .WithRequired(e => e.Orden_Cambio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orden_Cambio_Detalle>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio_Detalle>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio_Detalle>()
                .Property(e => e.PorcentajeAvance)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio_Detalle>()
                .Property(e => e.Predecesora)
                .IsUnicode(false);

            modelBuilder.Entity<Orden_Cambio_Detalle>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Cronograma)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proyecto>()
                .HasMany(e => e.Solicitud_Cambios)
                .WithRequired(e => e.Proyecto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Miembro_Proyecto)
                .WithRequired(e => e.Rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .HasMany(e => e.Informe_Cambio)
                .WithRequired(e => e.Solicitud_Cambios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Solicitud_Cambios>()
                .HasMany(e => e.Orden_Cambio)
                .WithRequired(e => e.Solicitud_Cambios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.Justificacion)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.PorcentajeAvance)
                .IsUnicode(false);

            modelBuilder.Entity<Tarea_ECS>()
                .Property(e => e.UrlGithub)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Usuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Tipo_Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Version_ECS>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<Version_ECS>()
                .Property(e => e.FechaInicio)
                .IsUnicode(false);

            modelBuilder.Entity<Version_ECS>()
                .Property(e => e.FechaTermino)
                .IsUnicode(false);

            modelBuilder.Entity<Version_ECS>()
                .HasMany(e => e.Tarea_ECS)
                .WithRequired(e => e.Version_ECS)
                .WillCascadeOnDelete(false);
        }
    }
}
