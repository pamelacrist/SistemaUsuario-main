namespace View
{
    public class Perfil
    {
        public static void CadastrarPerfil()
        {
            Console.WriteLine("Cadastrar Perfil");
            Console.WriteLine("Usuario_id:");
            int usuario_id = Console.ReadLine();
            Console.WriteLine("Perfil:");
            string perfil = Console.ReadLine();
            try {
                Controller.Perfil.CadastrarPerfil( placa, usuario_id,perfil);
                Console.WriteLine("Perfil cadastrado com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao cadastrar o perfil: {e.Message}");
            }
        }

        public static void AlterarPerfil()
        {
            Console.WriteLine("Alterar Perfil");
            Console.WriteLine("Id:");
            int id = Console.ReadLine();
            Console.WriteLine("Usuario_id:");
            int usuario_id = Console.ReadLine();
            Console.WriteLine("Perfil:");
            string perfil = Console.ReadLine();
            try {
                Controller.Perfil.AlterarPerfil(id, placa, motorista);
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
                Controller.Perfil.ExcluirPerfil(id);
                Console.WriteLine("Perfil excluído com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao excluir Perfil: {e.Message}");
            }
        }

    }
}