using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Produccion
    {
        public Produccion()
        {
            EntregaPedido = new HashSet<EntregaPedido>();
            PedidoRelacionProduccion = new HashSet<PedidoRelacionProduccion>();
        }

        public int IdProduccion { get; set; }
        public int IdProducto { get; set; }
        public DateTime? FechaProduccion { get; set; }
        public string DetalleProducto { get; set; }
        public int IdEstado { get; set; }
        public int Cantidad { get; set; }
        public int? IdPerfil { get; set; }

        public virtual EstadoProduccion IdEstadoNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<EntregaPedido> EntregaPedido { get; set; }
        public virtual ICollection<PedidoRelacionProduccion> PedidoRelacionProduccion { get; set; }
    }
}
