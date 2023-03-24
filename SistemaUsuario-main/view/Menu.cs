using System;

namespace View
{
    public class Menu
    {
        // Este método imprime o menu na tela
        public static void MostrarMenu()
        {
            System.Console.WriteLine("1 - Cadastrar usuário");
            System.Console.WriteLine("2 - Alterar usuário");
            System.Console.WriteLine("3 - Excluir usuário");
            System.Console.WriteLine("4 - Listar usuários");
            System.Console.WriteLine("5 - Listar usuários por tipo");
            System.Console.WriteLine("6 - Cadastrar perfil");
            System.Console.WriteLine("7 - Excluir perfil");
            System.Console.WriteLine("8 - Alterar perfis");
            System.Console.WriteLine("9 - Cadastrar sessão");
            System.Console.WriteLine("10 - Excluir sessão");
            System.Console.WriteLine("11 - Listar sessões ");
            System.Console.WriteLine("12 - Listar sessões totais");
            System.Console.WriteLine("13 - Listar sessões ativas");
            System.Console.WriteLine("0 - Sair");
            System.Console.WriteLine("Digite a opção desejada: ");
        }

        public static void ExibirMenu() {
            int opcao = -1;
            
            do {
                // Verifica se o usuário está logado e tem o perfil adequado
               if ( Middleware.Middleware.VerificarLogin())
                {
                    
                    Console.WriteLine("Usuario Logado!");
                }
                if ( Middleware.Middleware.VerificaPerfilUser())
                {
                   
                    Console.WriteLine("Usuario perfil User!");
                }
                if ( Middleware.Middleware.VerificaPerfilAdmin())
                {
                    
                    Console.WriteLine("Usuario perfil Admin!");
                }
               
                // Exibe o menu e aguarda a seleção do usuário
                MostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                 // Realiza a ação selecionada pelo usuário
                switch (opcao) {
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
                    case 5:
                        View.Usuario.ListarUsuariosTipo();
                        break;
                    case 6:
                        View.Perfil.CadastrarPerfil();
                        
                        break;
                    case 7:
                        View.Perfil.ExcluirPerfil();
                        
                        break;
                    case 8:
                        View.Perfil.AlterarPerfil();
                        
                        break;
                    case 9:
                        View.Sessao.Login();
                        break;
                    case 10:
                        View.Sessao.Logout();
                        break;
                    case 11: 
                        View.Sessao.ListarSessoes();
                         break;
                    case 12: 
                        View.Sessao.ListarTotal();
                         break;
                    case 13: 
                        View.Sessao.ListarAtivas();
                         break;
                    case 0:
                        System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
                        break;
                    default:
                        System.Console.WriteLine("Opção inválida!");
                        break;
                }
            } while (opcao != 0);
        }
    }
}