using System;
using System.Collections.Generic;

namespace Controller
{
    public class Sessao
    {
        // O método LogOff recebe um id do usuário e faz o logoff da sessão correspondente.
        public static void LogOff(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Sessao.Alterar(idConvert,new DateTime());
        }
        // O método BuscarSessao recebe um id da sessão e retorna a sessão correspondente.
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
        // O método ListarSessaos lista todas as sessões ativas.
        public static List<string> ListarSessaos()
        {
            return Model.Sessao.Listar();
        }
        // O método Login recebe um email e uma senha e retorna a sessão correspondente ao usuário.
        internal static Model.Sessao Login(string email, string senha)
        {
            return Model.Sessao.Login(email,senha);
           
        }

        // O método ListarTotal lista todas as sessões existentes.
        internal static IEnumerable<string> ListarTotal()
        {
            return Model.Sessao.ListarTotal();
        }

        // O método ListarAtivas lista todas as sessões ativas.
        internal static IEnumerable<string> ListarAtivas()
        {
        return Model.Sessao.ListarAtivas();
        }
    }
}