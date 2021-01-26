using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            EntregaPedidoRelacionTipoProducto = new HashSet<EntregaPedidoRelacionTipoProducto>();
            Producto = new HashSet<Producto>();
        }

        public int IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }

        public virtual ICollection<EntregaPedidoRelacionTipoProducto> EntregaPedidoRelacionTipoProducto { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
