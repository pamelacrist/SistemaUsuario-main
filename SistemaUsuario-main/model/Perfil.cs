using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Perfil
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public string _Perfil { get; set; }

        public Perfil(int id, int usuario_id, string perfil)
        {
             this.Id = id;
             this.Usuario_id = usuario_id;
             this._Perfil = perfil;
        }

        public Perfil(int usuario_id, string perfil)
        {
            this.Usuario_id = usuario_id;
             this._Perfil = perfil;
        }

        public Perfil()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario_id: {Usuario_id}, Perfil: {_Perfil}";
        }

        public static void AlterarPerfil(
            int id,
            int usuario_id,
            string perfil
        )
        {
            Perfil Perfil = BuscarPerfil(id);
            Perfil.Usuario_id = usuario_id;
            Perfil._Perfil = perfil;
        }

        public static void ExcluirPerfil(int id)
        {
        }

        public static List<Model.Perfil> ListarPerfil()
        {
            List<Model.Perfil> lista = new List<Model.Perfil>();
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);

            string selectQuery = "SELECT * FROM Perfil";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Perfil buscado = new Perfil()
                    {
                        Id = (int)reader["Id"],
                        Usuario_id = (int)reader["Usuario_id"],
                        _Perfil = (string)reader["Perfil"],
                    };
                   lista.Add( buscado);
                }
            }
            connection.Close();
            return lista;
        }


        public static Perfil BuscarPerfil(int id)
        {
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);

            string selectQuery = "SELECT * FROM Perfil WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Perfil buscado = new Perfil()
                    {
                        Id = (int)reader["Id"],
                        Usuario_id = (int)reader["Usuario_id"],
                        _Perfil = (string)reader["Perfil"],
                    };
                     return buscado;
                }
            }
            connection.Close();
            return null;
        }

    }
}