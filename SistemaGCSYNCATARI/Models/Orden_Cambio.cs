namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orden_Cambio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orden_Cambio()
        {
            Orden_Cambio_Detalle = new HashSet<Orden_Cambio_Detalle>();
        }

        [Key]
        public int Id_ordencambio { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaAprobacion { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(12)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descripción { get; set; }

        [Required]
        [StringLength(11)]
        public string PorcentajeAvance { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        public int Id_solicitud_cambios { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_Cambio_Detalle> Orden_Cambio_Detalle { get; set; }

        public virtual Solicitud_Cambios Solicitud_Cambios { get; set; }
    }
}
