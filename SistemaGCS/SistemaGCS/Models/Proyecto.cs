namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Spatial;

    [Table("Proyecto")]
    public partial class Proyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto()
        {
            Cronograma_Elemento = new HashSet<Cronograma_Elemento>();
            Miembro_Proyecto = new HashSet<Miembro_Proyecto>();
            Solicitud_Cambios = new HashSet<Solicitud_Cambios>();
        }

        [Key]
        public int Id_proyecto { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string FechaInicio { get; set; }

        [StringLength(50)]
        public string FechaTermino { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        public int Id_metodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_Elemento> Cronograma_Elemento { get; set; }

        public virtual Metodologia Metodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Proyecto> Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Cambios> Solicitud_Cambios { get; set; }

        // listar proyecto
        public List<Proyecto> Listar()
        {
            var sc = new List<Proyecto>();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Proyecto.Include("Metodologia").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;

        }
        // obtener solicitud
        public Proyecto Obtener(int id)
        {
            var sc = new Proyecto();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Proyecto.Include("Metodologia").Where(x => x.Id_proyecto == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;
        }

        // buscar solicitud
        public List<Proyecto> Buscar(string criterio)
        {
            var sc = new List<Proyecto>();

            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Proyecto.Include("Metodologia").Where(x => x.Nombre.Contains(criterio) ||
                                x.Codigo.Contains(criterio) ||
                                x.FechaInicio.Contains(criterio) ||
                                x.FechaTermino.Contains(criterio) ||
                                x.Estado.Contains(criterio))
                        .ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sc;
        }
        //guardar solicitud
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_proyecto > 0)
                    {
                        db.Entry(this).State = EntityState.Modified; //existe
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added; //nuevo registro
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
