using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int IdInsumo { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Cantidad { get; set; }
        public int ValorUnidadValorMetro { get; set; }
        public int ValorTotal { get; set; }
        public int? IdPerfil { get; set; }

        public virtual Insumos IdInsumoNavigation { get; set; }
        public virtual Perfil IdPerfilNavigation { get; set; }
    }
}
