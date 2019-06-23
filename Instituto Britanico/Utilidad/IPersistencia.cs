using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaBritanico.Utilidad
{
    interface IPersistencia<T>
    {
        bool Leer(string strCon);
        bool Guardar(string strCon);
        bool Modificar(string strCon);
        bool Eliminar(string strCon);
        List<T> GetAll(string strCon);
    }
}
