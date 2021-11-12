namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;
    using System.Linq;
    [Table("Version_ECS")]

    public partial class Version_ECS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Version_ECS()
        {
            Tarea_ECS = new HashSet<Tarea_ECS>();
        }

        [Key]
        public int Id_version { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        [Required]
        [StringLength(200)]
        public string Version { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaInicio { get; set; }

        [Required]
        [StringLength(255)]
        public string FechaTermino { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public int Id_miembro { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Miembro_Proyecto Miembro_Proyecto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea_ECS> Tarea_ECS { get; set; }
    }
}
