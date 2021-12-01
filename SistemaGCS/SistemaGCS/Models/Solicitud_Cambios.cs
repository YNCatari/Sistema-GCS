namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Cambios
    {
        [Key]
        public int Id_solicitud_cambios { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [StringLength(50)]
        public string Fecha { get; set; }

        [StringLength(50)]
        public string Objetivo { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string Respuesta { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_miembro { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        public virtual Proyecto Proyecto { get; set; }


        // listar solicitud
        public List<Solicitud_Cambios> Listar()
        {
            var sc = new List<Solicitud_Cambios>();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;

        }

        // obtener solicitud
        public Solicitud_Cambios Obtener(int id)
        {
            var sc = new Solicitud_Cambios();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").Where(x => x.Id_solicitud_cambios == id)
                                .SingleOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;
        }

        // buscar solicitud
        public List<Solicitud_Cambios> Buscar(string criterio)
        {
            var sc = new List<Solicitud_Cambios>();

            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Solicitud_Cambios.Include("Proyecto").Include("Miembro_Proyecto").Where(x => x.Codigo.Contains(criterio) ||
                                x.Fecha.Contains(criterio) || x.Objetivo.Contains(criterio) || x.Respuesta.Contains(criterio) ||
                                x.Proyecto.Codigo.Contains(criterio)).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sc;
        }
        //guardar solicitud
        public void Guardar()
        {
            try
            {
                using (var db = new ModelGCS())
                {
                    if (this.Id_solicitud_cambios > 0)
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
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
