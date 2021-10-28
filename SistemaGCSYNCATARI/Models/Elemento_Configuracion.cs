namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Elemento_Configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento_Configuracion()
        {
            Pantilla_elemento_configuracion = new HashSet<Pantilla_elemento_configuracion>();
            Version_ECS = new HashSet<Version_ECS>();
        }

        [Key]
        public int Id_elementoconfiguracion { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pantilla_elemento_configuracion> Pantilla_elemento_configuracion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version_ECS> Version_ECS { get; set; }


        ///METODO LISTAR
        public List<Elemento_Configuracion> Listar()
        {
            var elementos = new List<Elemento_Configuracion>();
            try
            {
                using (var db = new ModelGCS())
                {
                    elementos = db.Elemento_Configuracion.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return elementos;

        }

        ///METODO Buscar
        public List<Elemento_Configuracion> Buscar(string criterio)
        {
            var elementos = new List<Elemento_Configuracion>();

            try
            {
                using (var db = new ModelGCS())
                {
                    elementos = db.Elemento_Configuracion.Where(x => x.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return elementos;


        }


        ///METODO Obtener
        public Elemento_Configuracion Obtener(int id)
        {
            var elemento = new Elemento_Configuracion();
            try
            {
                using (var db = new ModelGCS())
                {
                    elemento = db.Elemento_Configuracion.Where(x => x.Id_elementoconfiguracion == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return elemento;
        }

        ///METODO Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_elementoconfiguracion > 0)
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
