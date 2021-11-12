namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Detalle_Informe")]

    public partial class Detalle_Informe
    {
        [Key]
        public int Id_detalle_informe { get; set; }

        public int Id_informe_cambio { get; set; }

        public int Id_cronograma_elemento_configuracion { get; set; }

        [Required]
        [StringLength(12)]
        public string Tiempo { get; set; }

        [Required]
        [StringLength(12)]
        public string Costo { get; set; }

        [Required]
        [StringLength(700)]
        public string Descripcion { get; set; }

        public virtual Informe_Cambio Informe_Cambio { get; set; }

        //Metodo Listar
        public List<Detalle_Informe> Listar()
        {
            var detalleInforme = new List<Detalle_Informe>();
            try
            {
                using (var db = new ModelGCS())
                {
                    detalleInforme = db.Detalle_Informe.Include("Cronograma_elemento_configuracion").Include("Informe_Cambio").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return detalleInforme;

        }

        //Metodo Obtener
        public Detalle_Informe Obtener(int id)
        {
            var detalleInforme = new Detalle_Informe();
            try
            {
                using (var db = new ModelGCS())
                {
                    detalleInforme = db.Detalle_Informe.Include("Cronograma_elemento_configuracion").Include("Informe_Cambio").Where(x => x.Id_detalle_informe == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return detalleInforme;
        }

        //Metodo Buscar
        public List<Detalle_Informe> Buscar(string criterio)
        {
            var detalleInforme = new List<Detalle_Informe>();

            try
            {
                using (var db = new ModelGCS())
                {
                    detalleInforme = db.Detalle_Informe.Include("Cronograma_elemento_configuracion").Include("Informe_Cambio").Where(x => x.Tiempo.Contains(criterio) ||
                                x.Costo.Contains(criterio) || x.Descripcion.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return detalleInforme;

        }

        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_detalle_informe > 0)
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
