using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelidex
{
    internal class Pelicula
    {
        private int _idPelicula;
        public string _nombrePelicula;
        public string _generoPelicula;

        public Pelicula(int idPelicula, string nombrePelicula, string generoPelicula)
        {
            _idPelicula = idPelicula;
            _nombrePelicula = nombrePelicula;
            _generoPelicula = generoPelicula;
        }
    }
}
