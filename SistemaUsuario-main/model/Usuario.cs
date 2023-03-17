using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Usuario
    {
        private String dataConvert;

        public int Id { get; set; }
        public String Data { get; set; }
        public String Valor { get; set; }

        public Perfil Perfil { get; internal set; }

        public Usuario(
            int id,
            String data,
            String valor
        )
        {
            Id = id;
            Data = data;
            Valor = valor;
        }

        public Usuario(String dataConvert, string valor)
        {
            this.dataConvert = dataConvert;
            this.Valor = valor;
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT INTO Usuario (Column1, Column2) VALUES (@value1, @value2)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@value1",  this.dataConvert);
            command.Parameters.AddWithValue("@value2", this.Valor);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Data: {Data}, Valor: {Valor} ";
        }

        public static void AlterarUsuario(
            int id,
            String data,
            string valor
        )
        {
            string updateQuery = "UPDATE Usuario SET Valor = @valor, Data = @data WHERE Id = @id";
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@data", data);
                command.Parameters.AddWithValue("@valor", valor);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Usuario BuscarUsuario(int id)
        {
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);

            string selectQuery = "SELECT * FROM Usuario WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Usuario usuarioBuscado = new Usuario()
                    {
                        Id = (int)reader["Id"],
                        Data = (string)reader["Data"],
                        Valor = (string)reader["Valor"],
                      
                    };
                     return usuarioBuscado;
                }
            }
            connection.Close();
            return null;
        }
        public static Usuario RemoverUsuario(int id)
        {
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string selectQuery = "DELETE FROM Usuario WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return null;
        }

    }
}