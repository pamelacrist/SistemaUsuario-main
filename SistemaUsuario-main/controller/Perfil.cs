namespace Controller
{
    public class Perfil
    {
       
        public static void Cadastrar(
            string usuario_id,
            string perfil
        ) {
            int usuario_idConvert = 0;
            try {
                usuario_idConvert = int.Parse(usuario_id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }

            Model.Perfil _perfil = new Model.Perfil( usuario_idConvert, perfil);
        }

        public static void Alterar(
            string id,
            string usuario_id,
            string perfil
        ) {
            int idConvert = 0;
            int usuario_idConvert = 0;
            try {
                
                usuario_idConvert = int.Parse(usuario_id);
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Perfil.AlterarPerfil(idConvert, usuario_idConvert, perfil);
        }

        public static void Excluir(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Perfil.ExcluirPerfil(idConvert);
        }

        public static Model.Perfil Buscar(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Perfil.BuscarPerfil(idConvert);
        }
        public static List<Model.Perfil> Listar()
        {
            return Model.Perfil.ListarPerfil();
        }
    }
}