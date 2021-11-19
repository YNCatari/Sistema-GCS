namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Miembro_Proyecto")]

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

        public virtual Rol Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud_Cambios> Solicitud_Cambios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Version_ECS> Version_ECS { get; set; }

        //POSIBLES ERRORES aqui va con rol
        //Metodo Listar
        public List<Miembro_Proyecto> Listar()
        {
            var mp = new List<Miembro_Proyecto>();
            try
            {
                using (var db = new ModelGCS())
                {
                    mp = db.Miembro_Proyecto.Include("Usuario").Include("Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return mp;

        }
        //Metodo Obtener
        public Miembro_Proyecto Obtener(int id)
        {
            var mp = new Miembro_Proyecto();
            try
            {
                using (var db = new ModelGCS())
                {
                    mp = db.Miembro_Proyecto.Include("Usuario").Include("Proyecto").Where(x => x.Id_miembro == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return mp;
        }
        //Metodo Buscar
        public List<Miembro_Proyecto> Buscar(string criterio)
        {
            var mp = new List<Miembro_Proyecto>();

            try
            {
                using (var db = new ModelGCS())
                {
                    mp = db.Miembro_Proyecto.Include("Usuario").Include("Proyecto").Where(x => x.Id_miembro.Equals(criterio) ||
                                x.Id_usuario.Equals(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return mp;

        }
        //Metodo Guardar
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
