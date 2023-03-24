using System;
using System.Collections.Generic;
using MySqlConnector;

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
           
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados
            string query = "INSERT INTO usuarios (nome, email, senha) VALUES (@nome, @email,@senha)";
            connection.Open(); // Abertura da conexão com o banco de dados
            MySqlCommand command = new MySqlCommand(query, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
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
            string updateQuery = "UPDATE usuarios SET nome = @nome, email = @email, senha = @senha WHERE id = @id";
            using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nome", nome);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);
                connection.Open(); // Abertura da conexão com o banco de dados
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static Usuario BuscarUsuario(int id)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            string selectQuery = "SELECT * FROM usuarios WHERE id = @id";
            connection.Open(); // Abertura da conexão com o banco de dados
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            command.Parameters.AddWithValue("@id", id);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Usuario usuarioBuscado = new Usuario()
                    {
                        Id = (int)reader["id"],
                        Nome = (string)reader["nome"],
                        Email = (string)reader["email"],
                      
                    };
                     return usuarioBuscado;
                }
            }
            connection.Close();
            return null;
        }
        public static Usuario RemoverUsuario(int id)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados
            string selectQuery = "DELETE FROM usuarios WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            command.Parameters.AddWithValue("@id", id);
            connection.Open(); // Abertura da conexão com o banco de dados
            command.ExecuteNonQuery();
            connection.Close();
            return null;
        }

        internal static Usuario BuscarPorEmail(string email)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            string selectQuery = "SELECT * FROM usuarios WHERE email = @email";
            connection.Open(); // Abertura da conexão com o banco de dados
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            command.Parameters.AddWithValue("@email", email);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Usuario usuarioBuscado = new Usuario()
                    {
                        Id = (int)reader["id"],
                        Nome = (string)reader["nome"],
                        Email = (string)reader["email"],
                        Senha = (string)reader["senha"],
                      
                    };
                     return usuarioBuscado;
                }
            }
            connection.Close();
            return null;
        }
    }
}