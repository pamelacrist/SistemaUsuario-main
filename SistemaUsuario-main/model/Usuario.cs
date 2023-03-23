using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Usuario
    {
        private String dataConvert;

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }

        public Perfil Perfil { get; internal set; }

      

        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT INTO Usuario (Column1, Column2, Column3) VALUES (@nome, @email,@senha)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@nome",  this.Nome);
            command.Parameters.AddWithValue("@email", this.Email);
            command.Parameters.AddWithValue("@senha", this.Senha);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
        }

        public Usuario()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Email: {Email} ";
        }

        public static void AlterarUsuario(
            int id,
            string nome,
            string email,
            string senha
        )
        {
            string updateQuery = "UPDATE Usuario SET nome = @nome, email = @email, senha = @senha WHERE Id = @id";
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
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
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                      
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