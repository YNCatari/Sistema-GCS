namespace SistemaGCSYNCATARI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Solicitud_Cambios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_Cambios()
        {
            Informe_Cambio = new HashSet<Informe_Cambio>();
            Orden_Cambio = new HashSet<Orden_Cambio>();
        }

        [Key]
        public int Id_solicitud_cambios { get; set; }

        [Required]
        [StringLength(100)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Fecha { get; set; }

        [Required]
        [StringLength(200)]
        public string Objetivo { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(200)]
        public string Respuesta { get; set; }

        [Required]
        [StringLength(200)]
        public string Estado { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_miembro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Informe_Cambio> Informe_Cambio { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orden_Cambio> Orden_Cambio { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
