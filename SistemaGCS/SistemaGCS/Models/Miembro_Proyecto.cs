namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Miembro_Proyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Miembro_Proyecto()
        {
            Solicitud_Cambios = new HashSet<Solicitud_Cambios>();
            Version_ECS = new HashSet<Version_ECS>();
        }

        [Key]
        public int Id_miembro { get; set; }

        public int Id_usuario { get; set; }

        public int Id_rol { get; set; }

        public int Id_proyecto { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Cambios> Solicitud_Cambios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version_ECS> Version_ECS { get; set; }


        public List<Miembro_Proyecto> Listar()
        {
            var miembro = new List<Miembro_Proyecto>();
            try
            {
                using (var db = new ModelGCS())
                {
                    miembro = db.Miembro_Proyecto
                         .Include("Usuario")
                        .Include("Rol")
                         .Include("Proyecto")
                        .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return miembro;
        }
        public Miembro_Proyecto Obtener(int id)
        {
            var miembro = new Miembro_Proyecto();
            try
            {
                using (var db = new ModelGCS())
                {
                    miembro = db.Miembro_Proyecto
                        .Where(x => x.Id_miembro == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return miembro;
        }

        public List<Miembro_Proyecto> Buscar(string criterio)
        {
            var miembro = new List<Miembro_Proyecto>();

            try
            {
                using (var db = new ModelGCS())
                {
                   

                }
            }
            catch (Exception)
            {
                throw;
            }

            return miembro;

        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_miembro > 0)
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

    }
}
