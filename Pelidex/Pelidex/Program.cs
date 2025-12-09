namespace Pelidex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            bool salir = true;

            do
            {
                Console.WriteLine("====\nMENU\n====\n" +
                "1) Listar Peliculas\n" +
                "2) Listar Generos de Peliculas\n" +
                "3) Listar info completa de Peliculas\n" +
                "4) Agregar Pelicula\n" +
                "5) Modificar Pelicula\n" +
                "6) Eliminar Pelicula\n" +
                "7) Agregar Genero\n" +
                "8) Modificar Genero\n" +
                "9) Eliminar Genero\n" +
                "Ingrese una opción: ");

                opcion = int.Parse(Console.ReadLine());
                Conexion connection = new Conexion();

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        List<Pelicula> peliculas = Consultas.ListarPeliculas();
                        foreach (Pelicula peli in peliculas)
                        {
                            Console.WriteLine($"{peli._nombrePelicula} - {peli._generoPelicula}");
                        }
                        break;
                    case 2:
                        Console.Clear(); //No puedo borrar
                        List<Genero> generos = Consultas.ListarGeneros();
                        foreach (Genero genero in generos)
                        {
                            Console.WriteLine($"{genero._descripcion}");
                        }
                        break;
                }
            } while (salir);

        }
    }
}
