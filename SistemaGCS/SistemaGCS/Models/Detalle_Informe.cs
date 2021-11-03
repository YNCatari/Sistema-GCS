namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
