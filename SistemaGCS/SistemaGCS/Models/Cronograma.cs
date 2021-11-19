namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Cronograma")]

    public partial class Cronograma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cronograma()
        {
            Cronograma_Fase = new HashSet<Cronograma_Fase>();
        }

        [Key]
        public int Id_cronograma { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaTermino { get; set; }

        public int Id_proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_Fase> Cronograma_Fase { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        ///METODO LISTAR
        public List<Cronograma> Listar()
        {
            var cronograma = new List<Cronograma>();
            try
            {
                using (var db = new ModelGCS())
                {
                    cronograma = db.Cronograma.Include("Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cronograma;

        }

        //Metodo Obtener
        public Cronograma Obtener(int id)
        {
            var cronograma = new Cronograma();
            try
            {
                using (var db = new ModelGCS())
                {
                    cronograma = db.Cronograma.Include("Proyecto").Where(x => x.Id_cronograma == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cronograma;
        }

        //Metodo Buscar
        public List<Cronograma> Buscar(string criterio)
        {
            var cronograma = new List<Cronograma>();

            try
            {
                using (var db = new ModelGCS())
                {
                    cronograma = db.Cronograma.Include("Proyecto").Where(x => x.FechaInicio.Contains(criterio)
                    || x.FechaTermino.Contains(criterio) ).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return cronograma;

        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_cronograma > 0)
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
