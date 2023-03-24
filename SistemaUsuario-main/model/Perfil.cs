using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Model
{
    public class Perfil
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public string _Perfil { get; set; }

        public Perfil(int usuario_id, string perfil)
        {
            this.Usuario_id = usuario_id;
            this._Perfil = perfil;
             // Cria uma conexão com o banco de dados
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados
            connection.Open(); // Abertura da conexão com o banco de dados
            // Prepara uma query para verificar se o usuário já possui um perfil cadastrado
            string select = "SELECT * FROM perfil where usuario_id = @usuario ";
            MySqlCommand commandSelect = new MySqlCommand(select, connection);
           
            commandSelect.Parameters.AddWithValue("@usuario", this.Usuario_id); // Atribuição do valor do parâmetro usuario_id à variável @usuario na string de instrução SQL
            using (MySqlDataReader reader = commandSelect.ExecuteReader()) // Utilização de um bloco using para instanciar um objeto MySqlDataReader com o objeto MySqlCommand como parâmetro, e a execução da leitura dos dados
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada // Verificação se há uma linha de dados retornada
                {
                    Console.WriteLine("Usuário já possui perfil."); // Exibição de uma mensagem no console indicando que o usuário já possui um perfil
                    return; 
                }
            }
            string query = "INSERT INTO perfil (usuario_id, perfil) VALUES (@Usuario_id, @Perfil)"; // Declaração de uma string contendo uma instrução SQL para inserir um novo perfil no banco de dados
            MySqlCommand command = new MySqlCommand(query, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros 
            command.Parameters.AddWithValue("@Usuario_id", this.Usuario_id); // Atribuição do valor do parâmetro usuario_id à variável @Usuario_id na string de instrução SQL
            command.Parameters.AddWithValue("@Perfil", this._Perfil); // Atribuição do valor do parâmetro perfil à variável @Perfil na string de instrução SQL
            command.ExecuteNonQuery(); // Execução da instrução SQL sem retornar dados
            Console.WriteLine("Perfil cadastrado com sucesso"); // Exibição de uma mensagem no console indicando que o perfil foi cadastrado com sucesso
            connection.Close(); // Fechamento da conexão com o banco de dados
        }

        // Construtor da classe com parâmetros
        public Perfil(int id, int usuario_id, string perfil)
        {
            // Atribui valores aos atributos
            this.Id = id;
            this.Usuario_id = usuario_id;
            this._Perfil = perfil;
        }
        public Perfil()
        {
        }
        // Retorna uma string representando o perfil
        public override string ToString()
        {
            return $"Id: {Id}, Usuario_id: {Usuario_id}, Perfil: {_Perfil}";
        }

        // Método estático para alterar perfil de um usuário
        public static void AlterarPerfil(
            int id,
            int usuario_id,
            string perfil
        )
        {
            // Busca o perfil pelo id
            string updateQuery = "UPDATE  sessoes SET usuario_id = @usuario_id, perfil = @perfil WHERE id = @id";
            using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
            {
                // Altera as propriedades do perfil
                MySqlCommand command = new MySqlCommand(updateQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@usuario_id", usuario_id);
                command.Parameters.AddWithValue("@perfil", perfil);
                connection.Open(); // Abertura da conexão com o banco de dados
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Método estático para excluir perfil de um usuário
        public static void ExcluirPerfil(int id)
        {
            // TODO: Implementar lógica para excluir perfil do usuário
        }

         // Método estático para listar todos os perfis cadastrados
        public static List<Model.Perfil> ListarPerfil()
        {
            List<Model.Perfil> lista = new List<Model.Perfil>();
            
            // Cria uma conexão com o banco de dados
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            connection.Open(); // Abertura da conexão com o banco de dados            // Prepara uma query para selecionar todos os perfis cadastrados
            string selectQuery = "SELECT * FROM perfil";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Perfil buscado = new Perfil()
                    {
                        Id = (int)reader["id"],
                        Usuario_id = (int)reader["usuario_id"],
                        _Perfil = (string)reader["perfil"],
                    };
                   lista.Add( buscado);
                }
            }
            connection.Close();
            return lista;
        }


        public static Perfil BuscarPerfil(int id)
        {
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados

            string selectQuery = "SELECT * FROM perfil WHERE id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            command.Parameters.AddWithValue("@id", id);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Perfil buscado = new Perfil()
                    {
                        Id = (int)reader["id"],
                        Usuario_id = (int)reader["usuario_id"],
                        _Perfil = (string)reader["perfil"],
                    };
                     return buscado;
                }
            }
            connection.Close();
            return null;
        }
        public static Perfil BuscarPerfilUsuario(int id=0)
        {
            if(id ==  0){
                return null;
            }
            MySqlConnection connection =  new MySqlConnection(Database.Database.connect); // Cria uma conexão com o banco de dados // Cria uma conexão com o banco de dados
            string selectQuery = "SELECT * FROM perfil WHERE usuario_id = @id";
            MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
            connection.Open(); // Abertura da conexão com o banco de dados
            command.Parameters.AddWithValue("@id", id);
            // Executa a query e adiciona os perfis encontrados na lista
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read()) // Verificação se há uma linha de dados retornada
                {
                    Perfil buscado = new Perfil()
                    {
                        Id = (int)reader["id"],
                        Usuario_id = (int)reader["usuario_id"],
                        _Perfil = (string)reader["perfil"],
                    };
                     return buscado;
                }
            }
            connection.Close();
            return null;
        }

    }
}