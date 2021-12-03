namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Cronograma_Elemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cronograma_Elemento()
        {
            Elemento_Configuracion = new HashSet<Elemento_Configuracion>();
        }

        [Key]
        public int Id_cronogramaelemento { get; set; }

        [StringLength(50)]
        public string FechaInicio { get; set; }

        [StringLength(50)]
        public string Fechafin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Configuracion> Elemento_Configuracion { get; set; }


        //Metodo Listar
        public List<Cronograma_Elemento> Listar()
        {
            var fase = new List<Cronograma_Elemento>();
            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;

        }
        //Metodo Obtener
        public Cronograma_Elemento Obtener(int id)
        {
            var fase = new Cronograma_Elemento();
            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.Where(x => x.Id_cronogramaelemento == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;
        }
        //Metodo Buscar
        public List<Cronograma_Elemento> Buscar(string criterio)
        {
            var fase = new List<Cronograma_Elemento>();

            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.Where(x => x.FechaInicio.Contains(criterio) ||
                                x.Fechafin.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_cronogramaelemento > 0)
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
