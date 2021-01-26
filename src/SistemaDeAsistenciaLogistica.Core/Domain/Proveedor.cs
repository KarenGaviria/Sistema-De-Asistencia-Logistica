using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Insumos = new HashSet<Insumos>();
        }

        public int IdProveedor { get; set; }
        public string Distribuidora { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Insumos> Insumos { get; set; }
    }
}
