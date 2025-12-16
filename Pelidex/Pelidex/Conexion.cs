using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelidex
{
    public class Conexion
    {
        //Variable de solo lectura que almacena texto
        private readonly string CadenaConexion; 
        private SqlConnection _connection;

        public Conexion()
        {
            //this.CadenaConexion = "Server=localhost\\SQL2014;Database=Pelidex;TrustServerCertificate=True;"; //Parametros de conexion: Servidor - Base de datos
            /*Notebook*/this.CadenaConexion = "Server=localhost\\SQL2014; Database=Pelidex; Persist Security Info=True; Integrated Security=SSPI;Connect Timeout=90;Pooling=true;Max Pool Size=400; Encrypt=False;";
            /*PC*///this.CadenaConexion = "Server=DESKTOP-CI79R3F; Database=Pelidex; Persist Security Info=True; Integrated Security=SSPI;Connect Timeout=90;Pooling=true;Max Pool Size=400; Encrypt=False;";
            this._connection = new SqlConnection(this.CadenaConexion);
        }

        //Hacer metodo que obtenga las pelis 
        public SqlConnection AbrirConexion()
        {
            try
            {
                if(this._connection.State == System.Data.ConnectionState.Closed)
                {
                    this._connection.Open();
                    //Console.WriteLine("Sistema conectado a SQLServer\n\n\n");
                }

            } catch (Exception ERROR)
            {
                Console.WriteLine($"Error! Conectando a la base: {ERROR}");
            } 

            return _connection;
        }

        public void CerrarConxion()
        {
            try
            {
                if (this._connection.State == System.Data.ConnectionState.Open)
                {
                    this._connection.Close();
                }

            }
            catch (Exception ERROR)
            {
                Console.WriteLine($"Error! Conectando a la base: {ERROR}");
            }
        }
    }
}
