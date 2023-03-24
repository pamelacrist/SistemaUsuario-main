using System;

namespace View
{
    public class Usuario
    {
        // Este método é responsável por receber os dados de um novo usuário e cadastrá-lo no sistema
        public static void CadastrarUsuario() {
            Console.WriteLine("Cadastrar Usuario");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();
            
            try {
                Controller.Usuario.CadastrarUsuario( nome, email,senha);
                Console.WriteLine("Usuario cadastrada com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        // Este método é responsável por receber o ID de um usuário existente e atualizar suas informações
        public static void AlterarUsuario() {
            Console.WriteLine("Alterar Usuario");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();
            
            try {
                Controller.Usuario.AlterarUsuario(id, nome, email,senha); // Chama o método "AlterarUsuario()" da classe "Usuario" do namespace "Controller"
                Console.WriteLine("Usuario alterada com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
         // Este método é responsável por receber o ID de um usuário existente e excluí-lo do sistema
        public static void ExcluirUsuario() {
            Console.WriteLine("Excluir Usuario");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            try {
                Controller.Usuario.ExcluirUsuario(id); // Chama o método "ExcluirUsuario()" da classe "Usuario" do namespace "Controller"
                Console.WriteLine("Usuario excluída com sucesso");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        // Este método é responsável por listar todos os usuários cadastrados no sistema
        public static void ListarUsuarios() {
            Console.WriteLine("Listar Usuarios");
            foreach (string usuario in Controller.Usuario.ListarUsuarios()) {
                Console.WriteLine(usuario); // Chama o método "ListarUsuarios()" da classe "Usuario" do namespace "Controller" e imprime na tela cada usuário retornado
            }
        }

        internal static void ListarUsuariosTipo()
        {
            Console.WriteLine("Listar Usuarios");
            foreach (string usuario in Controller.Usuario.ListarUsuariosTipo()) {
                Console.WriteLine(usuario); // Chama o método "ListarUsuarios()" da classe "Usuario" do namespace "Controller" e imprime na tela cada usuário retornado
            }
        }
    }
}