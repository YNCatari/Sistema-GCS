namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
