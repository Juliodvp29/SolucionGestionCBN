using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class Escuela
    {
        public Escuela()
        {
            Programas = new HashSet<Programa>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int FkDirector { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Programa> Programas { get; set; }
    }
}
