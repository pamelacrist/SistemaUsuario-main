
using MySql.Data.MySqlClient;
namespace Principal
{
    public class Programa
    {
        public static void Main(string[] args)  
        {
           
            Console.WriteLine("Usuarios: ");
            int opcao = 0;
            do {
                Console.WriteLine("1 - Cadastrar Usuario");
                Console.WriteLine("2 - Alterar Usuario");
                Console.WriteLine("3 - Excluir Usuario");
                Console.WriteLine("4 - Listar Usuarios");
                Console.WriteLine("5 - Media Usuario");
                Console.WriteLine("6 - Cadastrar Perfil");
                Console.WriteLine("7 - Alterar Perfil");  
                Console.WriteLine("8 - Excluir Perfil");
                Console.WriteLine("9 - Listar Perfil");
                Console.WriteLine("10 - Total de Usuarios por perfil");
                Console.WriteLine("11 - Valor das Usuarios por perfil");
                Console.WriteLine("12 - Cadastrar Sessao");
                Console.WriteLine("13 - Alterar Sessao");
                Console.WriteLine("14 - Excluir Sessao");
                Console.WriteLine("15 - Listar Sessaos");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("Opção:");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao) {
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    case 1:
                        View.Usuario.CadastrarUsuario();
                        break;
                    case 2:
                        View.Usuario.AlterarUsuario();
                        break;
                    case 3:
                        View.Usuario.ExcluirUsuario();
                        break;
                    case 4:
                        View.Usuario.ListarUsuarios();
                        break;
                        
                    case 6:  
                        View.Perfil.CadastrarPerfil();
                        break;
                    case 7:
                        View.Perfil.AlterarPerfil();
                        break;
                    case 8:
                        View.Perfil.ExcluirPerfil();
                        break;
                    case 9:
                        View.Perfil.ListarPerfil();
                        break;
                    case 10:
                     View.Perfil.TotalUsuariosPerfil(); 
                        break;
                    case 11:
                     View.Perfil.ValorUsuariosPerfil();
                       break;         
                    case 12:
                    View.Sessao.CadastrarSessao();
                        break;  
                    case 13:
                        View.Sessao.AlterarSessao();
                        break;
                    case 14:
                        View.Sessao.ExcluirSessao();
                        break;
                    case 15:
                        View.Sessao.ListarSessaos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 0);
        }
    }
}