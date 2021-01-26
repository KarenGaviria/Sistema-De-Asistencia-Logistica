using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Barrios
    {
        public Barrios()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdBarrio { get; set; }
        public string NombreBarrio { get; set; }

        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
