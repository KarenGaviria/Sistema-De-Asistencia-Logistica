using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class EntregaPedido
    {
        public EntregaPedido()
        {
            EntregaPedidoRelacionTipoProducto = new HashSet<EntregaPedidoRelacionTipoProducto>();
        }

        public int IdEntregaPedido { get; set; }
        public int IdPedido { get; set; }
        public int IdProduccion { get; set; }
        public DateTime? FechaEntrega { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Produccion IdProduccionNavigation { get; set; }
        public virtual ICollection<EntregaPedidoRelacionTipoProducto> EntregaPedidoRelacionTipoProducto { get; set; }
    }
}
