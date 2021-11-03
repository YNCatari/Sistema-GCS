namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cronograma")]
    public partial class Cronograma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cronograma()
        {
            Cronograma_Fase = new HashSet<Cronograma_Fase>();
        }

        [Key]
        public int Id_cronograma { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(10)]
        public string FechaTermino { get; set; }

        public int Id_proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cronograma_Fase> Cronograma_Fase { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
