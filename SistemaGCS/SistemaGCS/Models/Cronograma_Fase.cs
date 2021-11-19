namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Cronograma_Fase")]

    public partial class Cronograma_Fase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cronograma_Fase()
        {
            Cronograma_elemento_configuracion = new HashSet<Cronograma_elemento_configuracion>();
        }

        [Key]
        public int Id_cronograma_fase { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int Id_cronograma { get; set; }

        public virtual Cronograma Cronograma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_elemento_configuracion> Cronograma_elemento_configuracion { get; set; }

        ///METODO LISTAR
        public List<Cronograma_Fase> Listar()
        {
            var cf = new List<Cronograma_Fase>();
            try
            {
                using (var db = new ModelGCS())
                {
                    cf = db.Cronograma_Fase.Include("Cronograma").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cf;

        }

        //Metodo Obtener
        public Cronograma_Fase Obtener(int id)
        {
            var cf = new Cronograma_Fase();
            try
            {
                using (var db = new ModelGCS())
                {
                    cf = db.Cronograma_Fase.Include("Cronograma").Where(x => x.Id_cronograma_fase == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cf;
        }

        //Metodo Buscar
        public List<Cronograma_Fase> Buscar(string criterio)
        {
            var cf = new List<Cronograma_Fase>();

            try
            {
                using (var db = new ModelGCS())
                {
                    cf = db.Cronograma_Fase.Include("Cronograma").Where(x => x.Nombre.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return cf;

        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_cronograma_fase > 0)
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
