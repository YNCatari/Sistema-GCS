namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Cambios
    {
        [Key]
        public int Id_solicitud_cambios { get; set; }
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        [Required]
        [StringLength(50)]
        public string Fecha { get; set; }
        [Required]
        [StringLength(50)]
        public string Objetivo { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public string Respuesta { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_miembro { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
