using System;

namespace Model
{
    public class Sessao
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int token { get; set; }
        public int data_criacao { get; set; } 
        public int data_expiracao { get; set; }

        public static List<Sessao> Sessoes { get; set; } = new List<Sessao>();

        public Sessao(int id, string nome)
        {
            Id = id;
            Usuaria = usuario;
            Token = token;
            Data_criacao = data_criacao;
            ata_expiracao = data_expiracao;
            

            Sessaos.Add(this);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario: {Nome}, Token  ";
        }

        public static void AlterarSessao(
            int id,
            string nome
        )
        {
            Sessao sessao = BuscarSessao(id);
            sessao.Nome = nome;
        }

        public static void ExcluirSessao(int id)
        {
            Sessao sessao = BuscarSessao(id);
            Sessaos.Remove(sessao);
        }

        public static Sessao BuscarSessao(int id)
        {
            Sessao? sessao = Sessaos.Find(c => c.Id == id);
            if (sessao == null) {
                throw new Exception("Sessao não encontrada");
            }

            return sessao;
        }
    }
}