namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;

    [Table("Metodologia")]
    public partial class Metodologia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Metodologia()
        {
            Fase = new HashSet<Fase>();
            Proyecto = new HashSet<Proyecto>();
        }

        [Key]
        public int Id_metodologia { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fase> Fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }

        //Metodo Listar
        public List<Metodologia> Listar()
        {
            var metodologia = new List<Metodologia>();
            try
            {
                using (var db = new ModelGCS())
                {
                    metodologia = db.Metodologia.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return metodologia;

        }

        public List<Metodologia> Buscar(string criterio)
        {
            var metodologia = new List<Metodologia>();

            try
            {
                using (var db = new ModelGCS())
                {
                    metodologia = db.Metodologia.Where(x => x.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return metodologia;


        }


        public Metodologia Obtener(int id)
        {
            var metodologia = new Metodologia();
            try
            {
                using (var db = new ModelGCS())
                {
                    metodologia = db.Metodologia.Where(x => x.Id_metodologia == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return metodologia;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_metodologia > 0)
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
            catch (Exception)
            {
                throw;
            }
        }
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


