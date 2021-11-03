namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tarea_ECS
    {
        [Key]
        public int Id_tarea { get; set; }

        [Required]
        [StringLength(200)]
        public string Codigo { get; set; }

        public int Id_version { get; set; }

        public int Id_miembro { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(1000)]
        public string Justificacion { get; set; }

        [Required]
        [StringLength(11)]
        public string PorcentajeAvance { get; set; }

        [Required]
        [StringLength(2000)]
        public string UrlGithub { get; set; }

        public virtual Version_ECS Version_ECS { get; set; }
    }
}
