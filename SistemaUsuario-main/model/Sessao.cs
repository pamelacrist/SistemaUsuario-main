using System;
using System.Collections.Generic;
using System.Linq;
using MySqlConnector;

namespace Model
{
    public class Sessao
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string Token { get; set; }
        public DateTime Data_criacao { get; set; } 
        public DateTime Data_expiracao { get; set; }

        public Sessao(int id, int usuario, string token, DateTime data_criacao, DateTime data_expiracao)
        {
            Id = id;
            Usuario = usuario;
            Token = token;
            Data_criacao = data_criacao;
            Data_expiracao = data_expiracao;
            
        }

         public Sessao(int usuario)
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            this.Usuario = usuario;
            this.Token = token;
            this.Data_criacao = DateTime.UtcNow;
            this.Data_expiracao = DateTime.UtcNow + TimeSpan.FromDays(1);

            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados
            string query = "INSERT INTO sessoes (usuario_id , token, data_criacao, data_expiracao) VALUES (@Usuario, @Token, @Data_criacao, @Data_expiracao)";
            MySqlCommand command = new MySqlCommand(query, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            command.Parameters.AddWithValue("@Usuario",  this.Usuario);
            command.Parameters.AddWithValue("@Token", this.Token);
            command.Parameters.AddWithValue("@Data_criacao", this.Data_criacao);
            command.Parameters.AddWithValue("@Data_expiracao", this.Data_expiracao);
            command.ExecuteNonQuery();
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
            DateTime data_expiracao
        )
        {
            string updateQuery = "UPDATE  sessoes SET data_expiracao = @data_expiracao WHERE id = @id";
            using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
            {
                MySqlCommand command = new MySqlCommand(updateQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@data_expiracao", data_expiracao);
                connection.Open(); // Abertura da conexão com o banco de dados
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void Excluir(int id)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados
            string selectQuery = "DELETE FROM sessoes WHERE id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            command.Parameters.AddWithValue("@id", id);
            connection.Open(); // Abertura da conexão com o banco de dados
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static Sessao Buscar(int id)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            string selectQuery = "SELECT * FROM usuarios WHERE id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            command.Parameters.AddWithValue("@id", id);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Sessao buscado = new Sessao()
                    {
                        Id = (int)reader["id"],
                        Usuario = (int)reader["usuario_id"],
                        Token = (string)reader["token"],
                        Data_criacao = (DateTime)reader["data_criacao"],
                        Data_expiracao = (DateTime)reader["data_expiracao"],
                      
                    };
                    return buscado;
                }
            }
            connection.Close();
            return null;
        }
        public static Sessao Login(string email, string senha)
        {
            // Verificar se o email e a senha foram fornecidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                return null;
            }

            Model.Usuario usuario = Model.Usuario.BuscarPorEmail(email);
            if (usuario.Senha != senha) {
                throw new Exception("Senha inválida");
            }
            return new Model.Sessao(usuario.Id);

        }
        

        public static Sessao BuscarToken(string token)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            string selectQuery = "SELECT * FROM sessoes WHERE token = @token";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            command.Parameters.AddWithValue("@token", token);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Sessao buscado = new Sessao()
                    {
                        Id = (int)reader["id"],
                        Usuario = (int)reader["usuario_id"],
                        Token = (string)reader["token"],
                        Data_criacao = (DateTime)reader["data_criacao"],
                        Data_expiracao = (DateTime)reader["data_expiracao"],
                      
                    };
                    return buscado;
                }
            }
            connection.Close();
            return null;
        }

        internal static List<string> Listar()
            {
                string selectQuery = "SELECT * FROM sessoes";
                List<string> strings = new List<string>();
                using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
                {
                    MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                    connection.Open(); // Abertura da conexão com o banco de dados
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Model.Sessao sessao = new Model.Sessao();
                        sessao.Id = Convert.ToInt32(reader["Id"]);
                        sessao.Usuario = Convert.ToInt32(reader["usuario_id"]);
                        sessao.Data_criacao = Convert.ToDateTime(reader["data_criacao"]);
                        sessao.Data_expiracao = Convert.ToDateTime(reader["data_expiracao"]);
                        strings.Add(sessao.ToString());
                    }

                    reader.Close();
                    connection.Close();
                }

            return strings;
        }

        internal static IEnumerable<string> ListarAtivas()
        {
           string selectQuery = "SELECT count(*) as count FROM sessoes";
                List<string> strings = new List<string>();
                using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
                {
                    MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                    connection.Open(); // Abertura da conexão com o banco de dados
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       strings.Add(Convert.ToString(reader["count"]));
                    }

                    reader.Close();
                    connection.Close();
                }

            return strings;
        }

        internal static IEnumerable<string> ListarTotal()
        {
           string selectQuery = "SELECT count(*) as count FROM sessoes";
                List<string> strings = new List<string>();
                using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
                {
                    MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                    connection.Open(); // Abertura da conexão com o banco de dados
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       strings.Add(Convert.ToString(reader["count"]));
                    }

                    reader.Close();
                    connection.Close();
                }

            return strings;
        }
    }

   }