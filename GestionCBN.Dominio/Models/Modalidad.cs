using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class Modalidad
    {
        public Modalidad()
        {
            Programas = new HashSet<Programa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Programa> Programas { get; set; }
    }
}
