using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelidex
{
    internal static class Consultas
    {
        static Conexion conectar = new Conexion();
       
        public static List<Pelicula> ListarPeliculas()
        {
            List<Pelicula> peliculas = new List<Pelicula>();
            List<Genero> generos = ListarGeneros();

            using (SqlConnection con = conectar.AbrirConexion())
            {
                string consulta = "select id_Pelicula, nombre_pelicula, id_GeneroPelicula from Peliculas";
                using (SqlCommand cmdConsulta = new SqlCommand(consulta, con))
                {
                    using (SqlDataReader lectura = cmdConsulta.ExecuteReader()) //Se lee lo de la tabla y lo devuelve a la variable lectura
                    {
                            while (lectura.Read())
                            {
                                foreach (Genero gen in generos)
                                {
                                    if (Convert.ToInt32(lectura["id_GeneroPelicula"]) == gen._idGenero)
                                    {
                                        peliculas.Add(new Pelicula(Convert.ToInt32(lectura["id_Pelicula"]), lectura["nombre_pelicula"].ToString(), gen._descripcion));
                                    }
                                }

                            }
                    }
                }
            }
            return peliculas;
        }

        public static List<Genero> ListarGeneros()
        {
            List<Genero> generos = new List<Genero>();

            using (SqlConnection con = conectar.AbrirConexion())
            {
                string consulta = "select id_genero, descripcion from Genero";
                using (SqlCommand cmdConsulta = new SqlCommand(consulta, con))
                {
                    using (SqlDataReader lectura = cmdConsulta.ExecuteReader())
                    {
                        while (lectura.Read())
                        {
                            generos.Add(new Genero(Convert.ToInt32(lectura["id_Genero"]), lectura["descripcion"].ToString()));
                        }
                    }
                }
            }
            return generos;
        }



        /*public static List<Pelicula> ListarPeliculas()
        {
            List<Pelicula> peliculas = new List<Pelicula>();

            try
            {
                SqlConnection con = conectar.AbrirConexion();
                string consulta = "select id_Pelicula, nombre_pelicula, id_GeneroPelicula from Peliculas";

                SqlCommand cmdConsulta = new SqlCommand(consulta, con);
                SqlDataReader lectura = cmdConsulta.ExecuteReader(); //Se lee lo de la tabla y lo devuelve a la variable lectura

                while (lectura.Read())
                {
                    /*List<Genero> generos = Consultas.ListarGeneros();
                    foreach (Genero genero in generos)
                    {
                        if (Convert.ToInt32(lectura["id_GeneroPelicula"]) == genero._idGenero)
                        {
                            peliculas.Add(new Pelicula(Convert.ToInt32(lectura["id_Pelicula"]),lectura["nombre_pelicula"].ToString(),genero._descripcion));
                        }
                    }*/
                    /*string nombrePelicula = lectura["nombre_pelicula"].ToString();
                    Console.WriteLine(nombrePelicula);
                }
                lectura.Close();
            }
            catch (Exception ERROR)
            {
                Console.WriteLine($"Error consultando datos: {ERROR}");
            }
            finally
            {
                conectar.CerrarConxion();
            }
            return peliculas;
        }

        public static List<Genero> ListarGeneros()
        {
            List<Genero> generos = new List<Genero>();
            
            try
            {
                SqlConnection con = conectar.AbrirConexion();
                string consulta = "select id_genero, descripcion from Genero";

                SqlCommand cmdConsulta = new SqlCommand(consulta, con);
                SqlDataReader lectura = cmdConsulta.ExecuteReader(); //Se lee lo de la tabla y lo devuelve a la variable lectura


                while (lectura.Read())
                {
                    generos.Add(new Genero(Convert.ToInt32(lectura["id_Genero"]), lectura["descripcion"].ToString()));
                    //string descripcionGenero = lectura["descripcion"].ToString();
                    //Console.WriteLine(descripcionGenero);
                }
                lectura.Close();
            }
            catch (Exception ERROR)
            {
                Console.WriteLine($"Error consultando datos: {ERROR}");
            }
            finally
            {
                conectar.CerrarConxion();
            }
            return generos;
        }*/
    }
}
