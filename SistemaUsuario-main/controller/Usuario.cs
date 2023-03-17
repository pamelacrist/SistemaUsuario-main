using MySql.Data.MySqlClient;

namespace Controller
{
    public class Usuario
    {
        public int Id { get; private set; }

        private string? data;
        private string? valor;

        public static void CadastrarUsuario(
            string data,
            string valor
        )
        {
            Model.Usuario usuario = new Model.Usuario(data,valor);
          
        }
 
        public static void AlterarUsuario(
            string id,
            string data,
            string valor
        )
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Usuario.AlterarUsuario(idConvert, data,valor);
        }
 
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


 
        public static List<string> ListarUsuarios()
        {
                string connectionString = "server=localhost;user id=root;database=mydatabase";
                string selectQuery = "SELECT * FROM Usuario";
                List<string> stringUsuarios = new List<string>();
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(selectQuery, connection);
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["Id"]);
                        usuario.data = Convert.ToString(reader["Nome"]);
                        usuario.valor = Convert.ToString(reader["Email"]);
                        stringUsuarios.Add($"Id: {usuario.Id},Data: {usuario.data}, Valor: {usuario.valor}");
                    }

                    reader.Close();
                    connection.Close();
                }

            return stringUsuarios;
        }
    }
}