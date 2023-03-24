using System;
using System.Collections.Generic;

namespace Controller
{
    public class Perfil
    {
        // Método para cadastrar um novo perfil
        public static void Cadastrar(
            string usuario_id,
            string perfil
        ) {
            // Converte o id do usuário para int e trata possíveis erros
            int usuario_idConvert = 0;
            try {
                usuario_idConvert = int.Parse(usuario_id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }

            // Cria um novo perfil e o salva no banco de dados
            Model.Perfil _perfil = new Model.Perfil(usuario_idConvert, perfil);
        }

        // Método para alterar um perfil existente
        public static void Alterar(
            string id,
            string usuario_id,
            string perfil
        ) {
            // Converte os ids para int e trata possíveis erros
            int idConvert = 0;
            int usuario_idConvert = 0;
            try {
                usuario_idConvert = int.Parse(usuario_id);
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            // Chama o método para alterar o perfil no banco de dados
            Model.Perfil.AlterarPerfil(idConvert, usuario_idConvert, perfil);
        }

        // Método para excluir um perfil existente
        public static void Excluir(string id)
        {
            // Converte o id para int e trata possíveis erros
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            // Chama o método para excluir o perfil no banco de dados
            Model.Perfil.ExcluirPerfil(idConvert);
        }

        // Método para buscar um perfil pelo id
        public static Model.Perfil Buscar(string id)
        {
            // Converte o id para int e trata possíveis erros
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            // Chama o método para buscar o perfil no banco de dados e o retorna
            return Model.Perfil.BuscarPerfil(idConvert);
        }

        // Método para listar todos os perfis cadastrados
        public static List<Model.Perfil> Listar()
        {
            // Chama o método para listar todos os perfis no banco de dados e retorna a lista de perfis
            return Model.Perfil.ListarPerfil();
        }

        // Métodos abaixo ainda não foram implementados
        internal static IEnumerable<string> ValorUsuarios()
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<string> TotalUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
