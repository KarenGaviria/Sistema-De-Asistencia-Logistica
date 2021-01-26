using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Colores
    {
        public Colores()
        {
            Insumos = new HashSet<Insumos>();
        }

        public int IdColor { get; set; }
        public string Color { get; set; }

        public virtual ICollection<Insumos> Insumos { get; set; }
    }
}
