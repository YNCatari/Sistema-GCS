namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    public partial class Tipo_Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Usuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int Id_tipousuario { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        ///METODO LISTAR
        public List<Tipo_Usuario> Listar()
        {
            var tipousuario = new List<Tipo_Usuario>();
            try
            {
                using (var db = new ModelGCS())
                {
                    tipousuario = db.Tipo_Usuario.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tipousuario;

        }

        ///METODO Buscar
        public List<Tipo_Usuario> Buscar(string criterio)
        {
            var categorias = new List<Tipo_Usuario>();

            try
            {
                using (var db = new ModelGCS())
                {
                    categorias = db.Tipo_Usuario.Where(x => x.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return categorias;


        }


        ///METODO Obtener
        public Tipo_Usuario Obtener(int id)
        {
            var categoria = new Tipo_Usuario();
            try
            {
                using (var db = new ModelGCS())
                {
                    categoria = db.Tipo_Usuario.Where(x => x.Id_tipousuario == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return categoria;
        }

        ///METODO Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_tipousuario > 0)
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
    }
}