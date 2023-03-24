using System;

namespace Middleware
{
public class Middleware
    {
        // variável global para armazenar o token atual
        private static string tokenAtual = null;

        // método para verificar se o usuário está logado
        public static bool VerificarLogin()
        {
            // verifica se o token atual é válido e corresponde a um usuário logado
            if (tokenAtual != null && Logado(tokenAtual))
            {
                return true;
            }
            else
            {
                // redireciona o usuário para a página de login
                Console.WriteLine("Você precisa estar logado.");
                return false;
            }
        }


        // método para verificar se o usuário correspondente ao token de sessão está logado
        private static bool Logado(string token)
        {
            // implemente aqui a verificação de se o usuário correspondente ao token de sessão está logado
            return  Model.Sessao.BuscarToken(token).Data_expiracao != null;
        }

        // método para atualizar o token atual
        public static void AtualizarToken(string novoToken)
        {
            tokenAtual = novoToken;
        }

        internal static bool VerificaPerfilUser()
        {
            bool user = false;
            if(tokenAtual != null){
                Model.Sessao sessao = Model.Sessao.BuscarToken(tokenAtual);
                if(sessao != null){
                    Model.Perfil perfil = Model.Perfil.BuscarPerfilUsuario(sessao.Usuario);
                    if(perfil!= null){
                        user = perfil._Perfil == "user";
                    }
                }
            }
          return user ;
        }

        internal static bool VerificaPerfilAdmin()
        {
            bool user = false;
            if(tokenAtual != null){
                Model.Sessao sessao = Model.Sessao.BuscarToken(tokenAtual);
                if(sessao != null){
                    Model.Perfil perfil = Model.Perfil.BuscarPerfilUsuario(sessao.Usuario);
                    if(perfil!= null){
                        user = perfil._Perfil == "admin";
                    }
                }
            }
          return user ;
        }
    }
}
