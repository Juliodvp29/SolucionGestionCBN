using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
