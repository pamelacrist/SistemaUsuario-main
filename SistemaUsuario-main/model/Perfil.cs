using System;
using System.Collections.Generic;

namespace Model
{
    public class Perfil
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public string Perfil { get; set; }

        public static List<Perfil> perfils { get; set; } = new List<Perfil>();
        public string Usuario_id1 { get; }
        public Perfil Perfil1 { get; }

        public Perfil(int id, int usuario_id, string perfil)
        {
             this.Id = id;
             this.Usuario_id = usuario_id;
             this.Perfil = perfil;

            perfils.Add(this);
        }

        public Perfil(int usuario_id, string perfil)
        {
            this.Usuario_id = usuario_id;
             this.Perfil = perfil;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Usuario_id: {Usuario_id}, Perfil: {Perfil}";
        }

        public static void AlterarPerfil(
            int id,
            int usuario_id,
            string perfil
        )
        {
            Perfil Perfil = BuscarPerfil(id);
            Perfil.Usuario_id = usuario_id;
            Perfil.Perfil = perfil;
        }

        public static void ExcluirPerfil(int id)
        {
        }

        public static void BuscarPerfil(int id)
        {
        }
   }
}