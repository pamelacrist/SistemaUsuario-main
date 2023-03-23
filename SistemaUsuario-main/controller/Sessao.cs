namespace Controller
{
    public class Sessao
    {
        public static void CadastrarSessao( int usuario_id, string token, DateTime data_criacao, DateTime data_expiracao)
        {
            int tokenConvert = 0;
            try {
                tokenConvert = int.Parse(token);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Sessao sessao = new Model.Sessao(  usuario_id,  tokenConvert,  data_criacao,  data_expiracao);
        }

        public static void AlterarSessao(string id, int usuario_id, string token, DateTime data_criacao, DateTime data_expiracao)
        {
            int idConvert = 0;
            int tokenConvert = 0;
            try {
                idConvert = int.Parse(id);
                tokenConvert = int.Parse(token);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Sessao.Alterar(idConvert,  usuario_id,  tokenConvert,  data_criacao,  data_expiracao);
        }

        public static void ExcluirSessao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Sessao.Excluir(idConvert);
        }

        public static Model.Sessao BuscarSessao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Sessao.Buscar(idConvert);
        }

        public static List<Model.Sessao> ListarSessaos()
        {
            return null;
        }
    }
}