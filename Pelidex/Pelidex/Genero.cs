using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelidex
{
    internal class Genero
    {
        public int _idGenero;
        public string _descripcion;

        public Genero(int id_Genero,string descripcion)
        {
            _idGenero = id_Genero;
            _descripcion = descripcion;
        }
    }
}
