namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Cronograma_Elemento
    {
        [Key]
        public int Id_cronoele { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        [StringLength(50)]
        public string Fechainicio { get; set; }

        [StringLength(50)]
        public string Fechafin { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Proyecto Proyecto { get; set; }

        //Metodo Listar
        public List<Cronograma_Elemento> Listar()
        {
            var fase = new List<Cronograma_Elemento>();
            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.Include("Proyecto").Include("Elemento_Configuracion").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;

        }
        //Metodo Obtener
        public Cronograma_Elemento Obtener(int id)
        {
            var fase = new Cronograma_Elemento();
            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.Include("Proyecto").Include("Elemento_Configuracion").Where(x => x.Id_cronoele == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;
        }
        //Metodo Buscar
        public List<Cronograma_Elemento> Buscar(string criterio)
        {
            var fase = new List<Cronograma_Elemento>();

            try
            {
                using (var db = new ModelGCS())
                {
                    fase = db.Cronograma_Elemento.Include("Proyecto").Include("Elemento_Configuracion").Where(x => x.Fechainicio.Contains(criterio) ||
                                x.Fechafin.Contains(criterio) ||
                                x.Proyecto.Nombre.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return fase;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_cronoele > 0)
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
