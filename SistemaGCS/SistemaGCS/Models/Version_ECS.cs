namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Version_ECS")]

    public partial class Version_ECS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Version_ECS()
        {
            Tarea_ECS = new HashSet<Tarea_ECS>();
        }

        [Key]
        public int Id_version { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        [Required]
        [StringLength(200)]
        public string Version { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public int Id_miembro { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea_ECS> Tarea_ECS { get; set; }

        //Metodo Listar
        public List<Version_ECS> Listar()
        {
            var vECS = new List<Version_ECS>();
            try
            {
                using (var db = new ModelGCS())
                {
                    vECS = db.Version_ECS.Include("Miembro_Proyecto").Include("Elemento_Configuracion").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vECS;

        }
        //Metodo Obtener
        public Version_ECS Obtener(int id)
        {
            var vECS = new Version_ECS();
            try
            {
                using (var db = new ModelGCS())
                {
                    vECS = db.Version_ECS.Include("Miembro_Proyecto").Include("Elemento_Configuracion").Where(x => x.Id_version == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vECS;
        }
        //Metodo Buscar
        public List<Version_ECS> Buscar(string criterio)
        {
            var vECS = new List<Version_ECS>();

            try
            {
                using (var db = new ModelGCS())
                {
                    vECS = db.Version_ECS.Include("Miembro_Proyecto").Include("Elemento_Configuracion").Where(x => x.Version.Contains(criterio) ||
                                x.FechaInicio.Contains(criterio) || x.FechaTermino.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return vECS;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_version > 0)
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
