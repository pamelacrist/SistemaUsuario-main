using System;

namespace View
{
    public class Sessao
    {

        // Lista todas as sessões armazenadas no sistema
        public static void ListarSessoes() {
            Console.WriteLine("Listar Sessaos");
            foreach (string Sessao in Controller.Sessao.ListarSessaos()) {
                Console.WriteLine(Sessao);
            }
        }

        // Lista o número total de sessões armazenadas no sistema
        public static void ListarTotal() {
            Console.WriteLine("Listar Sessoes total");
            foreach (string Sessao in Controller.Sessao.ListarTotal()) {
                Console.WriteLine(Sessao);
            }
        }

        // Lista todas as sessões ativas no momento
        public static void ListarAtivas() {
            Console.WriteLine("Listar Sessoes ativas");
            foreach (string Sessao in Controller.Sessao.ListarAtivas()) {
                Console.WriteLine(Sessao);
            }
        }

        // Permite que um usuário faça login com seu email e senha
        internal static void Login()
        {
            Console.WriteLine("Login");
            Console.WriteLine("Digite o email");
            string email = Console.ReadLine();
            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();
            try
            {
                Model.Sessao sessao = Controller.Sessao.Login(email, senha);
                Console.WriteLine("Login efetuado com sucesso");
                Console.WriteLine(sessao);
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                Middleware.Middleware.AtualizarToken(sessao.Token);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Faz o logoff de uma sessão com o ID fornecido
        internal static void Logout()
        {
            Console.Clear();
            Console.WriteLine("Logoff");
            Console.WriteLine("Digite o id da sessão");
            string id = Console.ReadLine();
            try
            {
                Controller.Sessao.LogOff(id);
                Console.WriteLine("Logoff efetuado com sucesso");
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
