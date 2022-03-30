using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class Jornadum
    {
        public Jornadum()
        {
            Programas = new HashSet<Programa>();
        }

        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Programa> Programas { get; set; }
    }
}
