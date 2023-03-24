
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Controller
{
    public class Usuario
    {
        // Método para cadastrar um novo usuário
        public static void CadastrarUsuario(
            string nome,
            string email,
            string senha
        )
        {
            Model.Usuario usuario = new Model.Usuario(nome,email,senha);
          
        }
        // Método para alterar informações de um usuário existente
        public static void AlterarUsuario(
            string id,
            string nome,
            string email,
            string senha
        )
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Usuario.AlterarUsuario(idConvert, nome,email,senha);
        }
        // Método para remover um usuário pelo ID
        public static void ExcluirUsuario(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Usuario.RemoverUsuario(idConvert);
        }
        // Método para buscar um usuário pelo ID
        public static Model.Usuario BuscarUsuario(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Usuario.BuscarUsuario(idConvert);
        }
        // Método para listar todos os usuários do banco de dados
        public static List<string> ListarUsuarios()
        {
            string selectQuery = "SELECT * FROM usuarios";
            List<string> stringUsuarios = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                connection.Open(); // Abertura da conexão com o banco de dados
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Model.Usuario usuario = new Model.Usuario();
                    usuario.Id = Convert.ToInt32(reader["Id"]);
                    usuario.Nome = Convert.ToString(reader["Nome"]);
                    usuario.Email = Convert.ToString(reader["Email"]);
                    stringUsuarios.Add(usuario.ToString());
                }

                reader.Close();
                connection.Close();
            }

            return stringUsuarios;
        }

        internal static List<string> ListarUsuariosTipo()
        {
           string selectQuery = "SELECT count(*) as count, perfil FROM perfil group by perfil";
            List<string> stringUsuarios = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(Database.Database.connect))
            {
                MySqlCommand command = new MySqlCommand(selectQuery, connection); // Instanciação de um objeto MySqlCommand com a string de instrução SQL e o objeto MySqlConnection como parâmetros
                connection.Open(); // Abertura da conexão com o banco de dados
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stringUsuarios.Add(Convert.ToString(" quantidade:" +reader["count"]+" perfil:" +reader["perfil"]));
                }

                reader.Close();
                connection.Close();
            }
            return stringUsuarios;
        }
    }
}