namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Spatial;

    public partial class Elemento_Configuracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Elemento_Configuracion()
        {
            Cronograma_Elemento = new HashSet<Cronograma_Elemento>();
            Version_ECS = new HashSet<Version_ECS>();
        }

        [Key]
        public int Id_elementoconfiguracion { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Nomenclatura { get; set; }

        public int Id_fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_Elemento> Cronograma_Elemento { get; set; }

        public virtual Fase Fase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version_ECS> Version_ECS { get; set; }

        //Metodo Listar
        public List<Elemento_Configuracion> Listar()
        {
            var elementoConfiguracion = new List<Elemento_Configuracion>();
            try
            {
                using (var db = new ModelGCS())
                {
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").ToList();
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
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").Where(x => x.Id_elementoconfiguracion == id)
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
                    elementoConfiguracion = db.Elemento_Configuracion.Include("Fase").Where(x => x.Nombre.Contains(criterio) ||
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
                    if (this.Id_fase > 0)
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
