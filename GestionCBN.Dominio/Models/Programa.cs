using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class Programa
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Siglas { get; set; }
        public int FkEscuela { get; set; }
        public int FkModalidad { get; set; }
        public string FkJornada { get; set; }
        public string PerfilOcupacional { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Ofertado { get; set; }
        public bool? Estado { get; set; }
        public int? DescuentoProntoPago { get; set; }

        public virtual Escuela FkEscuelaNavigation { get; set; }
        public virtual Jornadum FkJornadaNavigation { get; set; }
        public virtual Modalidad FkModalidadNavigation { get; set; }
    }
}
