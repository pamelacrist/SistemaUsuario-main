namespace View
{
    public class Sessao
    {
        public static void CadastrarSessao()
        {
            Console.WriteLine("Digite o id da Sessao:");
            string id = Console.ReadLine();
            Console.WriteLine("Digite o id do Usuario:");
            int usuario_id = Console.ReadLine();
            Console.WriteLine("Digite o Token:");
            string token = Console.ReadLine();
            Console.WriteLine("Digite a data da criacao:");
            DateTime data_criacao = Console.ReadLine();
            Console.WriteLine("Digite a data do termino:");
            DateTime data_expiracao = Console.ReadLine();

            
            try {
                Controller.Sessao.CadastrarSessao(id, nome);
                Console.WriteLine("Sessao cadastrada com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao cadastrar Sessao: {e.Message}");
            }
        }

        public static void AlterarSessao()
        {
            Console.WriteLine("Digite o id da Sessao:");
            string id = Console.ReadLine();
            Console.WriteLine("Digite o nome da Sessao:");
            string nome = Console.ReadLine();
            try {
                Controller.Sessao.AlterarSessao(id, nome);
                Console.WriteLine("Sessao alterada com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao alterar Sessao: {e.Message}");
            }
        }

        public static void ExcluirSessao()
        {
            Console.WriteLine("Digite o id da Sessao:");
            string id = Console.ReadLine();
            try {
                Controller.Sessao.ExcluirSessao(id);
                Console.WriteLine("Sessao excluída com sucesso");
            } catch (Exception e) {
                Console.WriteLine($"Erro ao excluir Sessao: {e.Message}");
            }
        }

        public static void ListarSessaos() {
            Console.WriteLine("Listar Sessaos");
            foreach (Model.Sessao Sessao in Controller.Sessao.ListarSessaos()) {
                Console.WriteLine(Sessao);
            }
        }

        
    }
}