using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdCotizacion { get; set; }
        public int IdPerfil { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int? ValorTotal { get; set; }

        public virtual Perfil IdPerfilNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
