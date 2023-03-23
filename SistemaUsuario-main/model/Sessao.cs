using System;
using MySql.Data.MySqlClient;

namespace Model
{
    public class Sessao
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Token { get; set; }
        public DateTime Data_criacao { get; set; } 
        public DateTime Data_expiracao { get; set; }

        public Sessao(int id, int usuario, int token, DateTime data_criacao, DateTime data_expiracao)
        {
            Id = id;
            Usuario = usuario;
            Token = token;
            Data_criacao = data_criacao;
            Data_expiracao = data_expiracao;
            
        }

         public Sessao(int usuario, int token, DateTime data_criacao, DateTime data_expiracao)
        {
            Usuario = usuario;
            Token = token;
            Data_criacao = data_criacao;
            Data_expiracao = data_expiracao;
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "INSERT INTO Sessao (Column1, Column2, Column3, Column4) VALUES (@Usuario, @Token, @Data_criacao, @Data_expiracao)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Usuario",  this.Usuario);
            command.Parameters.AddWithValue("@Token", this.Token);
            command.Parameters.AddWithValue("@Data_criacao", this.Data_criacao);
            command.Parameters.AddWithValue("@Data_expiracao", this.Data_expiracao);
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            
        }

        public Sessao()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario: {Usuario}, Token: {Token}, Data criacao: {Data_criacao}, Data expiracao: {Data_expiracao} ";
        }

        public static void Alterar(
            int id,
            int usuario,
            int token,
            DateTime data_criacao,
            DateTime data_expiracao
        )
        {
           string updateQuery = "UPDATE Sessao SET Valor = @valor, Data = @data WHERE Id = @id";
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@token", token);
                command.Parameters.AddWithValue("@data_criacao", data_criacao);
                command.Parameters.AddWithValue("@data_expiracao", data_expiracao);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Excluir(int id)
        {
            string connectionString = "server=localhost;user id=root;database=mydatabase";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string selectQuery = "DELETE FROM Sessao WHERE Id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static Sessao Buscar(int id)
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
                    Sessao buscado = new Sessao()
                    {
                        Id = (int)reader["Id"],
                        Usuario = (int)reader["Usuario"],
                        Token = (int)reader["Token"],
                        Data_criacao = (DateTime)reader["Data_criacao"],
                        Data_expiracao = (DateTime)reader["Data_expiracao"],
                      
                    };
                    return buscado;
                }
            }
            connection.Close();
            return null;
        }
    }
}