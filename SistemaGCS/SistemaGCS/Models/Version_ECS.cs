namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Spatial;

    public partial class Version_ECS
    {
        [Key]
        public int Id_version { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        [StringLength(50)]
        public string Version { get; set; }

        [StringLength(50)]
        public string FechaInicio { get; set; }

        [StringLength(50)]
        public string FechaTermino { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string URL { get; set; }

        public int Id_miembro { get; set; }

        [StringLength(50)]
        public string Avance { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }


        // listar solicitud
        public List<Version_ECS> Listar()
        {
            var sc = new List<Version_ECS>();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Version_ECS.Include("Elemento_Configuracion").Include("Miembro_Proyecto").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sc;

        }

        // obtener solicitud
        public Version_ECS Obtener(int id)
        {
            var sc = new Version_ECS();
            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Version_ECS.Include("Elemento_Configuracion").Include("Miembro_Proyecto").Where(x => x.Id_version == id)
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
        public List<Version_ECS> Buscar(string criterio)
        {
            var sc = new List<Version_ECS>();

            try
            {
                using (var db = new ModelGCS())
                {
                    sc = db.Version_ECS.Include("Elemento_Configuracion").Include("Miembro_Proyecto").Where(x => x.Version.Contains(criterio) ||
                                x.Descripcion.Contains(criterio) || x.FechaInicio.Contains(criterio) || x.FechaTermino.Contains(criterio) ||
                                x.URL.Contains(criterio) || x.Avance.Contains(criterio)).ToList();

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
                    if (this.Id_version > 0)
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
