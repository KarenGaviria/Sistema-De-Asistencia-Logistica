using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Perfil
    {
        public Perfil()
        {
            Cotizacion = new HashSet<Cotizacion>();
            Inventario = new HashSet<Inventario>();
            Produccion = new HashSet<Produccion>();
        }

        public int IdUsuarios { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Direccion { get; set; }
        public string AspnetusersId { get; set; }

        public virtual Aspnetusers Aspnetusers { get; set; }
        public virtual ICollection<Cotizacion> Cotizacion { get; set; }
        public virtual ICollection<Inventario> Inventario { get; set; }
        public virtual ICollection<Produccion> Produccion { get; set; }
    }
}
