namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fase")]
    public partial class Fase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fase()
        {
            Elemento_Configuracion = new HashSet<Elemento_Configuracion>();
        }

        [Key]
        public int Id_fase { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int Id_metodologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Elemento_Configuracion> Elemento_Configuracion { get; set; }

        public virtual Metodologia Metodologia { get; set; }
    }
}
