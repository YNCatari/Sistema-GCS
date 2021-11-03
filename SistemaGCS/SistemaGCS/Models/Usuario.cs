namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Proyecto = new HashSet<Proyecto>();
        }

        [Key]
        public int Id_usuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int Id_tipousuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }

        public virtual Tipo_Usuario Tipo_Usuario { get; set; }

        ModelGCS db = new ModelGCS();


        //Metodo Listar
        public List<Usuario> Listar()
        {
            var usuarios = new List<Usuario>();
            try
            {
                using (var db = new ModelGCS())
                {
                    usuarios = db.Usuario.Include("Tipo_Usuario").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;

        }
        //Metodo Obtener
        public Usuario Obtener(int id)
        {
            var usuarios = new Usuario();
            try
            {
                using (var db = new ModelGCS())
                {
                    usuarios = db.Usuario.Include("Tipo_Usuario").Where(x => x.Id_usuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }
        //Metodo Buscar
        public List<Usuario> Buscar(string criterio)
        {
            var usuarios = new List<Usuario>();

            try
            {
                using (var db = new ModelGCS())
                {
                    usuarios = db.Usuario.Include("Tipo_Usuario").Where(x => x.Nombre.Contains(criterio) ||
                                x.Apellido.Contains(criterio) || x.Correo.Contains(criterio) ||
                                x.Tipo_Usuario.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_usuario > 0)
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


        //login
        public bool Autenticar()
        {

            return db.Usuario
                   .Where(x => x.Correo == this.Correo
                   && x.Password == this.Password)
                   .FirstOrDefault() != null;
        }
        //obtener datos del login
        public Usuario ObtenerDatos(string Correo)
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new ModelGCS())
                {
                    usuario = db.Usuario.Include("Tipo_Usuario")
                        .Where(x => x.Correo == Correo)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }





    }
}
