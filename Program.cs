using GerenciadorBiblioteca.AppConsole;
bool stop = false;

List<Livro> livros = [];
List<Usuario> usuarios = [];
List<Emprestimo> emprestimos = [];
int ContadorLivros = 1;
int ContadorUsuarios = 1;
int ContadorEmprestimos = 1;

Console.Clear();

do
{
    Console.Clear();

    // TODO: Reorganizar o menu
    Console.WriteLine("Bem-vindo ao sistema de gerenciamento de biblioteca");
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Cadastrar livro");
    Console.WriteLine("2 - Cadastrar usuário");
    // TODO: Implementar edição de usuário
    // TODO: Implementar edição de livro
    Console.WriteLine("3 - Realizar empréstimo");
    Console.WriteLine("4 - Devolver livro");
    Console.WriteLine("5 - Listar livros");
    Console.WriteLine("6 - Listar usuários");
    // TODO: Implementar consulta detalhada de usuário
    // TODO: Implementar consulta detalhada de livro
    Console.WriteLine("7 - Listar empréstimos");
    Console.WriteLine("8 - Remover Usuário");
    Console.WriteLine("9 - Remover Livro");
    Console.WriteLine("10 - Sair");
    Console.Write("Digite o número da opção desejada:");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Cadastrar livro
            Livro livro = new();
            do
            {
                Console.Clear();
                Console.WriteLine("---------------Cadastro de Livros------------------");
                try
                {
                    Console.WriteLine("Digite o título do livro:");
                    livro.Titulo = Console.ReadLine();

                    Console.WriteLine("Digite o autor do livro:");
                    livro.Autor = Console.ReadLine();

                    Console.WriteLine("Digite o ISBN do livro:");
                    livro.ISBN = Console.ReadLine();

                    Console.WriteLine("Digite o ano de publicação do livro:");
                    livro.AnoPublicacao = int.Parse(Console.ReadLine());

                    livro.Id = ContadorLivros++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar livro, tente novamente! Ex:" + ex.Message);
                }
            } while (livro.Id == 0);

            livros.Add(livro);
            break;
        case "2":
        // Cadastrar usuário
            Usuario usuario = new();
            do 
            {
                Console.Clear();
                Console.WriteLine("---------------Cadastro de usuário-----------------");
                try
                {
                    Console.WriteLine("Digite o nome do usuário:");
                    usuario.Nome = Console.ReadLine();

                    Console.WriteLine("Digite o email do usuário:");
                    usuario.Email = Console.ReadLine();

                    usuario.Id = ContadorUsuarios++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar usuário, tente novamente! Ex:" + ex.Message);
                }
            } while (usuario.Id == 0);
            
            usuarios.Add(usuario);
            break;
        case "3":
        // Realizar empréstimo
            Console.Clear();
            Console.WriteLine("-------------Cadastro de empréstimo----------------");
            Emprestimo emprestimo = new(){
                Id = ContadorEmprestimos++
            };
            do
            {
                Console.WriteLine("Digite o ISBN do Livro:");
                string isbnLivro = Console.ReadLine();
                try
                {
                    // TODO: Corrigir situação de livro não encontrado, a propriedade não permite nulo
                    emprestimo.Livro = livros.Find(l => l.ISBN == isbnLivro);
                }
                catch (Exception)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente!");
                }  
                // TODO: trocar por flag de saída
            } while (emprestimo.Livro == null);
            
            do
            {
                Console.WriteLine("Digite o e-mail do usuário:");
                string emailUsuario = Console.ReadLine();
                try
                {
                    // TODO: Corrigir situação de usuário não encontrado, a propriedade não permite nulo
                    emprestimo.Usuario = usuarios.Find(u => u.Email == emailUsuario);
                }
                catch (Exception)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente!");
                }
                // TODO: trocar por flag de saída
            } while (emprestimo.Usuario == null);

            do 
            {
                Console.WriteLine("Escolha um prazo de devolução:");
                Console.WriteLine("1 - 7 dias");
                Console.WriteLine("2 - 15 dias");
                Console.WriteLine("3 - 30 dias");

                string opcaoData = Console.ReadLine();

                emprestimo.DataDevolucao = opcaoData switch
                {
                    "1" => DateTime.Now.AddDays(7),
                    "2" => DateTime.Now.AddDays(15),
                    "3" => DateTime.Now.AddDays(30),
                    _ => DateTime.MinValue,
                };

            } while (emprestimo.DataDevolucao == DateTime.MinValue);

            emprestimos.Add(emprestimo);
            break;
        case "4":
        // Devolver livro
            bool devolvido = false;
            do
            {
                Console.Clear();
                Console.WriteLine("------------Devolução de empréstimo----------------");
                try
                {
                    Console.WriteLine("Digite o ID do empréstimo:");
                    int emprestimoId = int.Parse(Console.ReadLine());
                    emprestimos.Find(e => e.Id == emprestimoId).DataDevolucao = DateTime.Now;
                    devolvido = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Empréstimo não encontrado, tente novamente!");
                    Console.WriteLine("Deseja tentar novamente? (S/N)");
                    string tentarNovamente = Console.ReadLine();
                    devolvido = tentarNovamente.ToUpper() == "N" ? true : false;
                }
                
            } while (devolvido = false);
           
            if (devolvido == true)
            {
                Console.WriteLine("Livro devolvido com sucesso!");
                Console.WriteLine("Lista de empréstimos atualizada:");
                foreach (Emprestimo e in emprestimos)
                {
                    Console.WriteLine($"ID: {e.Id} - Livro: {e.Livro.Titulo} - Usuário: {e.Usuario.Nome} - Data de empréstimo: {e.DataEmprestimo} - Data de devolução: {e.DataDevolucao}");
                }
            }

            break;
        case "5":
        // Listar livros
            Console.Clear();
            Console.WriteLine("-------------Listagem de livros--------------------");
            foreach (Livro l in livros)
            {
                Console.WriteLine($"ID: {l.Id} - Título: {l.Titulo} - Autor: {l.Autor} - ISBN: {l.ISBN} - Ano de publicação: {l.AnoPublicacao}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadKey();

            break;
        case "6":
        // Listar usuários
            Console.Clear();
            Console.WriteLine("-------------Listagem de usuários------------------");
            foreach (Usuario u in usuarios)
            {
                Console.WriteLine($"ID: {u.Id} - Nome: {u.Nome} - Email: {u.Email}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadKey();
            break;
        case "7":
        // Listar empréstimos
            Console.Clear();
            Console.WriteLine("-------------Listagem de empréstimos--------------");
            foreach (Emprestimo e in emprestimos)
            {
                Console.WriteLine($"ID: {e.Id} - Livro: {e.Livro.Titulo} - Usuário: {e.Usuario.Nome} - Data de empréstimo: {e.DataEmprestimo} - Data de devolução: {e.DataDevolucao}");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadKey();
            break;
        case "8":
        // Remover Usuário
            Console.Clear();
            Console.WriteLine("-------------Remoção de Usuário-------------------");
            Console.WriteLine("Digite o ID do usuário que deseja remover:");
            // TODO: Implementar validação de entrada
            // TODO: Implementar visualização de usuários
            int idUsuario = int.Parse(Console.ReadLine());
            Usuario usuarioRemover = usuarios.Find(u => u.Id == idUsuario);
            usuarios.Remove(usuarioRemover);
            break;
        case "9":
        // Remover Livro
            Console.Clear();
            Console.WriteLine("-------------Remoção de Livro---------------------");
            Console.WriteLine("Digite o ISBN do livro que deseja remover:");
            // TODO: Implementar validação de entrada
            // TODO: Implementar visualização de usuários
            string isbnLivroRemover = Console.ReadLine();
            Livro livroRemover = livros.Find(l => l.ISBN == isbnLivroRemover);
            livros.Remove(livroRemover);
            break;
        case "10":
        // Sair
            stop = true;
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;  
    }

} while (stop == false);

