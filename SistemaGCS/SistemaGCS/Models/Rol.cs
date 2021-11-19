namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;


    [Table("Rol")]
    public partial class Rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rol()
        {
            Miembro_Proyecto = new HashSet<Miembro_Proyecto>();
        }

        [Key]
        public int Id_rol { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Miembro_Proyecto> Miembro_Proyecto { get; set; }

        ModelGCS db = new ModelGCS();


        //Metodo Listar
        public List<Rol> Listar()
        {
            var roles = new List<Rol>();
            try
            {
                using (var db = new ModelGCS())
                {
                    roles = db.Rol.Include("Miembro_Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return roles;

        }
        //Metodo Obtener
        public Rol Obtener(int id)
        {
            var roles = new Rol();
            try
            {
                using (var db = new ModelGCS())
                {
                    roles = db.Rol.Include("Miembro_Proyecto").Where(x => x.Id_rol == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return roles;
        }
        //Metodo Buscar
        public List<Rol> Buscar(string criterio)
        {
            var roles = new List<Rol>();

            try
            {
                using (var db = new ModelGCS())
                {
                    roles = db.Rol.Include("Miembro_Proyecto").Where(x => x.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return roles;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_rol > 0)
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
        //Metodo Eliminar
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
