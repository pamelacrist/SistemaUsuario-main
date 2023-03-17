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

        public Perfil(int id, int Usuario_id, string Perfil)
        {
            Id = id;
            Usuario_id = usuario_id;
            Perfil = perfil;

            perfils.Add(this);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Placa: {Usuario_id}, Motorista: {Perfil}";
        }

        public static void AlterarPerfil(
            int id,
            string placa,
            string motorista
        )
        {
            Perfil Perfil = BuscarPerfil(id);
            Perfil.Placa = placa;
            Perfil.Motorista = motorista;
        }

        public static void ExcluirPerfil(int id)
        {
            Perfil Perfil = BuscarPerfil(id);
            Caminhoes.Remove(Perfil);
        }

        public static Perfil BuscarPerfil(int id)
        {
            Perfil? Perfil = Caminhoes.Find(c => c.Id == id);
            if (Perfil == null) {
                throw new Exception("Caminhão não encontrado");
            }

            return Perfil;
        }
   }
}