namespace View
{
    public class Usuario
    {
        public static void CadastrarUsuario() {
            Console.WriteLine("Cadastrar Usuario");
            Console.WriteLine("Id:");
            int id = Console.ReadLine();
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();
            
            try {
                Controller.Usuario.CadastrarUsuario( nome, email,Senha);
                Console.WriteLine("Usuario cadastrada com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public static void AlterarUsuario() {
            Console.WriteLine("Alterar Usuario");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            Console.WriteLine("Nome:");
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();
            
            try {
                Controller.Usuario.AlterarUsuario(id, nome, email,senha);
                Console.WriteLine("Usuario alterada com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public static void ExcluirUsuario() {
            Console.WriteLine("Excluir Usuario");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            try {
                Controller.Usuario.ExcluirUsuario(id);
                Console.WriteLine("Usuario excluída com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public static void ListarUsuarios() {
            Console.WriteLine("Listar Usuarios");
            foreach (string usuario in Controller.Usuario.ListarUsuarios()) {
                Console.WriteLine(usuario);
            }
        }    
    }
}