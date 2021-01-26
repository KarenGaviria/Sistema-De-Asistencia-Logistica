using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Insumos
    {
        public Insumos()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int IdInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public int? IdColor { get; set; }
        public int IdProveedor { get; set; }

        public virtual Colores IdColorNavigation { get; set; }
        public virtual Proveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
