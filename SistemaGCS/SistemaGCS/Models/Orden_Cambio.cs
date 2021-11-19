namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Orden_Cambio")]

    public partial class Orden_Cambio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden_Cambio()
        {
            Orden_Cambio_Detalle = new HashSet<Orden_Cambio_Detalle>();
        }

        [Key]
        public int Id_ordencambio { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaAprobacion { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripción { get; set; }

        [Required]
        [StringLength(11)]
        public string PorcentajeAvance { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        public int Id_solicitud_cambios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_Cambio_Detalle> Orden_Cambio_Detalle { get; set; }

        public virtual Solicitud_Cambios Solicitud_Cambios { get; set; }


        //Metodo Listar
        public List<Orden_Cambio> Listar()
        {
            var oc = new List<Orden_Cambio>();
            try
            {
                using (var db = new ModelGCS())
                {
                    oc = db.Orden_Cambio.Include("Solicitud_Cambios").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return oc;

        }
        //Metodo Obtener
        public Orden_Cambio Obtener(int id)
        {
            var oc = new Orden_Cambio();
            try
            {
                using (var db = new ModelGCS())
                {
                    oc = db.Orden_Cambio.Include("Solicitud_Cambios").Where(x => x.Id_ordencambio == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return oc;
        }
        //Metodo Buscar
        public List<Orden_Cambio> Buscar(string criterio)
        {
            var oc = new List<Orden_Cambio>();

            try
            {
                using (var db = new ModelGCS())
                {
                    oc = db.Orden_Cambio.Include("Solicitud_Cambios").Where(x => x.Descripción.Contains(criterio) ||
                                x.FechaAprobacion.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return oc;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_ordencambio > 0)
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
