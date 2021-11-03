namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
