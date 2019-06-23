using BibliotecaBritanico.Modelo;
using Instituto_Britanico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instituto_Britanico.Interfaces
{
    public interface IEstudiante
    {
        void RecibirEstudiante(Estudiante e, TipoTransferencia tt);

    }
}
