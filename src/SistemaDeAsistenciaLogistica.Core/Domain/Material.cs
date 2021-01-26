using System;
using System.Collections.Generic;

namespace SistemaDeAsistenciaLogistica.Core.Domain
{
    public partial class Material
    {
        public Material()
        {
            Producto = new HashSet<Producto>();
        }

        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
