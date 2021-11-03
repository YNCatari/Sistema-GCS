namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orden_Cambio_Detalle
    {
        [Key]
        public int Id_orden_cambio_detalle { get; set; }

        public int Id_ordencambio { get; set; }

        public int Id_elemento_configuracion { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(11)]
        public string PorcentajeAvance { get; set; }

        [Required]
        [StringLength(200)]
        public string Predecesora { get; set; }

        [Required]
        [StringLength(700)]
        public string Descripcion { get; set; }

        public virtual Orden_Cambio Orden_Cambio { get; set; }
    }
}
