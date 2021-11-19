namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Cronograma_elemento_configuracion")]
    public partial class Cronograma_elemento_configuracion
    {
        [Key]
        public int Id_elemento_configuracion { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Codigo { get; set; }

        public int Id_cronograma_fase { get; set; }

        public virtual Cronograma_Fase Cronograma_Fase { get; set; }


        ///METODO LISTAR
        public List<Cronograma_elemento_configuracion> Listar()
        {
            var cec = new List<Cronograma_elemento_configuracion>();
            try
            {
                using (var db = new ModelGCS())
                {
                    cec = db.Cronograma_elemento_configuracion.Include("Cronograma_Fase").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cec;

        }

        //Metodo Obtener
        public Cronograma_elemento_configuracion Obtener(int id)
        {
            var cec = new Cronograma_elemento_configuracion();
            try
            {
                using (var db = new ModelGCS())
                {
                    cec = db.Cronograma_elemento_configuracion.Include("Cronograma_Fase").Where(x => x.Id_elemento_configuracion == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cec;
        }

        //Metodo Buscar
        public List<Cronograma_elemento_configuracion> Buscar(string criterio)
        {
            var cec = new List<Cronograma_elemento_configuracion>();

            try
            {
                using (var db = new ModelGCS())
                {
                    cec = db.Cronograma_elemento_configuracion.Include("Cronograma_Fase").Where(x => x.Nombre.Contains(criterio)
                    || x.Codigo.Contains(criterio)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return cec;

        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_elemento_configuracion > 0)
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
