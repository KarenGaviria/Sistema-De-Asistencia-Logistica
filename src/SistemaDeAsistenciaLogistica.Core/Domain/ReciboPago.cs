using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class ReciboPago
    {
        public int IdReciboPago { get; set; }
        public int? IdPedido { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
