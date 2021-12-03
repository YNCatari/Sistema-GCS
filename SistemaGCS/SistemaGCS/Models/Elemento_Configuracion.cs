namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Elemento_Configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento_Configuracion()
        {
            Miembro_Elemento = new HashSet<Miembro_Elemento>();
        }

        [Key]
        public int Id_elementoconfiguracion { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Nomenclatura { get; set; }

        public int Id_fase { get; set; }
        [Required]
        [StringLength(50)]
        public string Url { get; set; }

        public int Id_cronogramaelemento { get; set; }

        public virtual Cronograma_Elemento Cronograma_Elemento { get; set; }

        public virtual Fase Fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Elemento> Miembro_Elemento { get; set; }

        //Metodo Listar
        public List<Elemento_Configuracion> Listar()
        {
            var elementoConfiguracion = new List<Elemento_Configuracion>();
            try
            {
                using (var db = new ModelGCS())
                {
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").Include("Cronograma_Elemento").ToList();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

            return elementoConfiguracion;

        }
        //Metodo Obtener
        public Elemento_Configuracion Obtener(int id)
        {
            var elementoConfiguracion = new Elemento_Configuracion();
            try
            {
                using (var db = new ModelGCS())
                {
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").Include("Cronograma_Elemento").Where(x => x.Id_elementoconfiguracion == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return elementoConfiguracion;
        }
        //Metodo Buscar
        public List<Elemento_Configuracion> Buscar(string criterio)
        {
            var elementoConfiguracion = new List<Elemento_Configuracion>();

            try
            {
                using (var db = new ModelGCS())
                {
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").Include("Cronograma_Elemento").Where(x => x.Nombre.Contains(criterio) ||
                                x.Fase.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return elementoConfiguracion;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_elementoconfiguracion > 0)
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
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.ToString());
                throw;
            }
        }
        






    }
}
