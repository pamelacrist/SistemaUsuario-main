namespace Controller
{
    public class Sessao
    {
        public static void CadastrarSessao(string id, string nome)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Sessao sessao = new Model.Sessao(idConvert, nome);
        }

        public static void AlterarSessao(string id, string nome)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Sessao.AlterarSessao(idConvert, nome);
        }

        public static void ExcluirSessao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Sessao.ExcluirSessao(idConvert);
        }

        public static Model.Sessao BuscarSessao(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Sessao.BuscarSessao(idConvert);
        }

        public static List<Model.Sessao> ListarSessaos()
        {
            return Model.Sessao.Sessaos;
        }
    }
}