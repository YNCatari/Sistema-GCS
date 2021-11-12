namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Solicitud_Cambios")]

    




    public partial class Solicitud_Cambios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_Cambios()
        {
            Informe_Cambio = new HashSet<Informe_Cambio>();
            Orden_Cambio = new HashSet<Orden_Cambio>();
        }

        [Key]
        public int Id_solicitud_cambios { get; set; }

        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Fecha { get; set; }

        [Required]
        [StringLength(200)]
        public string Objetivo { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(200)]
        public string Respuesta { get; set; }

        [Required]
        [StringLength(200)]
        public string Estado { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_miembro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informe_Cambio> Informe_Cambio { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_Cambio> Orden_Cambio { get; set; }

        public virtual Proyecto Proyecto { get; set; }


        //Metodo Listar
        public List<Solicitud_Cambios> Listar()
        {
            var solicitudCambios = new List<Solicitud_Cambios>();
            try
            {
                using (var db = new ModelGCS())
                {
                    solicitudCambios = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return solicitudCambios;

        }

        //Metodo Obtener
        public Solicitud_Cambios Obtener(int id)
        {
            var solicitudCambios = new Solicitud_Cambios();
            try
            {
                using (var db = new ModelGCS())
                {
                    solicitudCambios = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").Where(x => x.Id_solicitud_cambios == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return solicitudCambios;
        }

        //Metodo Buscar
        public List<Solicitud_Cambios> Buscar(string criterio)
        {
            var solicitudCambios = new List<Solicitud_Cambios>();

            try
            {
                using (var db = new ModelGCS())
                {
                    solicitudCambios = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").Where(x => x.Codigo.Contains(criterio) ||
                                x.Fecha.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return solicitudCambios;

        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_solicitud_cambios > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        ///METODO Eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new ModelGCS())
                {

                    db.Entry(this).State = EntityState.Deleted;

                    db.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
