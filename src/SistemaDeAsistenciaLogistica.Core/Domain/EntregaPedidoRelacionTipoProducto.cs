using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class EntregaPedidoRelacionTipoProducto
    {
        public int IdEntregaPedidoRelacionTipoProducto { get; set; }
        public int IdEntregaPedido { get; set; }
        public int IdTipoProducto { get; set; }

        public virtual EntregaPedido IdEntregaPedidoNavigation { get; set; }
        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
    }
}
