using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class EstadoProduccion
    {
        public EstadoProduccion()
        {
            Produccion = new HashSet<Produccion>();
        }

        public int IdEstado { get; set; }
        public string EstadoProduccion1 { get; set; }

        public virtual ICollection<Produccion> Produccion { get; set; }
    }
}
