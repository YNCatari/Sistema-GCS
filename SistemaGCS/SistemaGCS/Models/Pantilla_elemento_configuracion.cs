namespace SistemaGCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pantilla_elemento_configuracion
    {
        [Key]
        public int Id_plantilla { get; set; }

        public int Id_fase { get; set; }

        public int Id_elementoconfiguracion { get; set; }

        public virtual Elemento_Configuracion Elemento_Configuracion { get; set; }

        public virtual Fase Fase { get; set; }
    }
}
