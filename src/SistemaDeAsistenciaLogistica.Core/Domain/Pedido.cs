using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Pedido
    {
        public Pedido()
        {
            EntregaPedido = new HashSet<EntregaPedido>();
            PedidoRelacionProduccion = new HashSet<PedidoRelacionProduccion>();
            ReciboPago = new HashSet<ReciboPago>();
        }

        public int IdPedido { get; set; }
        public int IdCotizacion { get; set; }
        public DateTime? FechaPedido { get; set; }
        public string LugarEntrega { get; set; }
        public int IdBarrio { get; set; }

        public virtual Barrios IdBarrioNavigation { get; set; }
        public virtual Cotizacion IdCotizacionNavigation { get; set; }
        public virtual ICollection<EntregaPedido> EntregaPedido { get; set; }
        public virtual ICollection<PedidoRelacionProduccion> PedidoRelacionProduccion { get; set; }
        public virtual ICollection<ReciboPago> ReciboPago { get; set; }
    }
}
