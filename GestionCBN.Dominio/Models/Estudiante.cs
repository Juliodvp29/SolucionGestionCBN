using System;
using System.Collections.Generic;

#nullable disable

namespace GestionCBN.Dominio.Models
{
    public partial class Estudiante
    {
        public int Id { get; set; }
        public int FkTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string CorreoElectronico { get; set; }
        public string Direccion { get; set; }
        public int FkEstadoCivil { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }

        public virtual EstadoCivil FkEstadoCivilNavigation { get; set; }
        public virtual TipoDocumento FkTipoDocumentoNavigation { get; set; }
    }
}
