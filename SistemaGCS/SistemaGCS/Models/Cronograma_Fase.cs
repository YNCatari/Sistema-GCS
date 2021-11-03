namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cronograma_Fase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cronograma_Fase()
        {
            Cronograma_elemento_configuracion = new HashSet<Cronograma_elemento_configuracion>();
        }

        [Key]
        public int Id_cronograma_fase { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        public int Id_cronograma { get; set; }

        public virtual Cronograma Cronograma { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_elemento_configuracion> Cronograma_elemento_configuracion { get; set; }
    }
}
