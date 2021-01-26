using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Producto
    {
        public Producto()
        {
            Cotizacion = new HashSet<Cotizacion>();
            Produccion = new HashSet<Produccion>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public int IdMaterial { get; set; }
        public int IdTipoProducto { get; set; }
        public int PrecioUnidad { get; set; }

        public virtual Material IdMaterialNavigation { get; set; }
        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual ICollection<Produccion> Produccion { get; set; }
    }
}
