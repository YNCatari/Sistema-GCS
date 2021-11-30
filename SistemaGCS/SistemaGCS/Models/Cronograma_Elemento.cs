namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cronograma_Elemento
    {
        [Key]
        public int Id_cronoele { get; set; }

        public int Id_proyecto { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        [StringLength(50)]
        public string Fechainicio { get; set; }

        [StringLength(50)]
        public string Fechafin { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Proyecto Proyecto { get; set; }
    }
}
