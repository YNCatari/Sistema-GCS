namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Version_ECS
    {
        [Key]
        public int Id_version { get; set; }

        public int Id_elementoconfiguracion { get; set; }
        [Required]
        [StringLength(50)]
        public string Version { get; set; }
        [Required]
        [StringLength(50)]
        public string FechaInicio { get; set; }
        [Required]
        [StringLength(50)]
        public string FechaTermino { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string URL { get; set; }

        public int Id_miembro { get; set; }
        [Required]
        [StringLength(50)]
        public string Avance { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }
    }
}
