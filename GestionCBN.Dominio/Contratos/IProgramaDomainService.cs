using GestionCBN.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCBN.Dominio.Contratos
{
   public interface IProgramaDomainService
    {
        Programa create(Programa programa);
    }
}
