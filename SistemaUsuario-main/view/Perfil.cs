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
                Controller.Perfil.Cadastrar( usuario_id,perfil);
                Console.WriteLine("Perfil cadastrado com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao cadastrar o perfil: {e.Message}");
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
                Console.WriteLine("Perfil alterado com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao alterar o Perfil: {e.Message}");
            }
        }

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

        internal static void ListarPerfil()
        {
            Console.WriteLine("Listar Perfil");
            foreach (Model.Perfil perfil in Controller.Perfil.Listar()) {
                Console.WriteLine(perfil.ToString());
            }
        }
    }
}