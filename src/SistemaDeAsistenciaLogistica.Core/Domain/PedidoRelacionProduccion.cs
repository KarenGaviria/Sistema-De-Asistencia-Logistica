using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class PedidoRelacionProduccion
    {
        public int IdPedidoRelacionProduccion { get; set; }
        public int IdPedido { get; set; }
        public int IdProduccion { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual Produccion IdProduccionNavigation { get; set; }
    }
}
