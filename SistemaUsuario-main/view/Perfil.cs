using System;

namespace View
{
    public class Perfil
    {
          public static void CadastrarPerfil()
        {
            Console.WriteLine("Cadastrar Perfil");
            Console.WriteLine("Usuario_id:");
            string usuario_id = Console.ReadLine();
            Console.WriteLine("Perfil:");
            string perfil = Console.ReadLine();
            try {
                Controller.Perfil.Cadastrar(usuario_id, perfil);
                // tenta cadastrar o perfil com o método da classe Controller.Perfil
            } catch (Exception e) {
                Console.WriteLine($"Erro ao cadastrar o perfil: {e.Message}");
                // se ocorrer algum erro, exibe a mensagem de erro
            }
        }

        public static void AlterarPerfil()
        {
            Console.WriteLine("Alterar Perfil");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            Console.WriteLine("Usuario_id:");
            string usuario_id = Console.ReadLine();
            Console.WriteLine("Perfil:");
            string perfil = Console.ReadLine();
            try {
                Controller.Perfil.Alterar(id, usuario_id, perfil);
                // tenta alterar o perfil com o método da classe Controller.Perfil
            } catch (Exception e) {
                Console.WriteLine($"Erro ao alterar o Perfil: {e.Message}");
                // se ocorrer algum erro, exibe a mensagem de erro
            }
        }
        // Função que exclui um perfil
        public static void ExcluirPerfil()
        {
            Console.WriteLine("Excluir Perfil");
            Console.WriteLine("Id:");
            string id = Console.ReadLine();
            try {
                Controller.Perfil.Excluir(id);
                Console.WriteLine("Perfil excluído com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao excluir Perfil: {e.Message}");
            }
        }

        // Função que lista os perfis cadastrados
        internal static void ListarPerfil()
        {
            Console.WriteLine("Listar Perfil");
            foreach (Model.Perfil perfil in Controller.Perfil.Listar()) {
                Console.WriteLine(perfil.ToString());
            }
        }

        // Função que lista o total de usuários em cada perfil
        internal static void TotalUsuariosPerfil()
        {
            Console.WriteLine("Listar Perfil");
            foreach (String perfil in Controller.Perfil.TotalUsuarios()) {
                Console.WriteLine(perfil.ToString());
            }
        }

        // Função que lista o valor médio dos salários dos usuários em cada perfil
        internal static void ValorUsuariosPerfil()
        {
            Console.WriteLine("Listar Perfil");
            foreach (String perfil in Controller.Perfil.ValorUsuarios()) {
                Console.WriteLine(perfil.ToString());
            }
        }
    }
}