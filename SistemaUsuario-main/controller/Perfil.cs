namespace Controller
{
    public class Perfil
    {
        private static void ValidaPlaca(
            string placa
        ) {
            string[] placaSplit = placa.Split('-');
            if (placaSplit.Length != 2) {
                throw new Exception("Placa inválida");
            }
            if (placaSplit[0].Length != 3) {
                throw new Exception("Placa inválida");
            }
            if (placaSplit[1].Length != 4) {
                throw new Exception("Placa inválida");
            }

            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numeros = "0123456789";

            foreach (char letra in placaSplit[0]) {
                if (!letras.Contains(letra.ToString())) {
                    throw new Exception("Placa inválida");
                }
            }

            foreach (char numero in placaSplit[1]) {
                if (!numeros.Contains(numero.ToString())) {
                    throw new Exception("Placa inválida");
                }
            }
        }

        public static void CadastrarPerfil(
            string id,
            string placa,
            string motorista
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }

            ValidaPlaca(placa);
            Model.Perfil perfil = new Model.Perfil(idConvert, placa, motorista);
        }

        public static void AlterarPerfil(
            string id,
            string placa,
            string motorista
        ) {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            ValidaPlaca(placa);
            Model.Perfil.AlterarPerfil(idConvert, placa, motorista);
        }

        public static void ExcluirPerfil(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            Model.Perfil.ExcluirPerfil(idConvert);
        }

        public static Model.Perfil BuscarPerfil(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            
            return Model.Perfil.BuscarPerfil(idConvert);
        }
        public static double ValorUsuarios(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Perfil perfil = Model.Perfil.BuscarPerfil(idConvert);
            return 0;
        }

        public static double TotalUsuarios(string id)
        {
            int idConvert = 0;
            try {
                idConvert = int.Parse(id);
            } catch (Exception) {
                throw new Exception("Id inválido");
            }
            Model.Perfil perfil = Model.Perfil.BuscarPerfil(idConvert);
            return 0;
        }
        public static List<Model.Perfil> ListarCaminhoes()
        {
            return Model.Perfil.Caminhoes;
        }
    }
}