namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Informe_Cambio")]
    public partial class Informe_Cambio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Informe_Cambio()
        {
            Detalle_Informe = new HashSet<Detalle_Informe>();
        }

        [Key]
        public int Id_informe_cambio { get; set; }

        [Required]
        [StringLength(20)]
        public string Codigo { get; set; }

        public int Id_solicitud_cambios { get; set; }

        [Required]
        [StringLength(400)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(2000)]
        public string Tiempo { get; set; }

        [Required]
        [StringLength(12)]
        public string CostoEconomico { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImpactoProblema { get; set; }

        [Required]
        [StringLength(12)]
        public string Fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        public int Id_miembro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle_Informe> Detalle_Informe { get; set; }

        public virtual Solicitud_Cambios Solicitud_Cambios { get; set; }

        //Metodo Listar
        public List<Informe_Cambio> Listar()
        {
            var ic = new List<Informe_Cambio>();
            try
            {
                using (var db = new ModelGCS())
                {
                    ic = db.Informe_Cambio.Include("Solicitud_Cambios").Include("Miembro_Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ic;

        }
        //Metodo Obtener
        public Informe_Cambio Obtener(int id)
        {
            var ic = new Informe_Cambio();
            try
            {
                using (var db = new ModelGCS())
                {
                    ic = db.Informe_Cambio.Include("Solicitud_Cambios").Include("Miembro_Proyecto").Where(x => x.Id_informe_cambio == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ic;
        }
        //Metodo Buscar
        public List<Informe_Cambio> Buscar(string criterio)
        {
            var ic = new List<Informe_Cambio>();

            try
            {
                using (var db = new ModelGCS())
                {
                    ic = db.Informe_Cambio.Include("Solicitud_Cambios").Include("Miembro_Proyecto").Where(x => x.Codigo.Contains(criterio) ||
                                x.Descripcion.Contains(criterio) || x.Tiempo.Contains(criterio) || x.CostoEconomico.Contains(criterio))
                                .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return ic;

        }
        //Metodo Guardar
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_informe_cambio > 0)
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
