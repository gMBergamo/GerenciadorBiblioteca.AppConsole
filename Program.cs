using GerenciadorBiblioteca.AppConsole;
bool stop = false;
bool continuar = false;

List<Livro> livros = [];
List<Usuario> usuarios = [];
List<Emprestimo> emprestimos = [];
int ContadorLivros = 1;
int ContadorUsuarios = 1;
int ContadorEmprestimos = 1;



do
{
    string opcao = "";

    Console.WriteLine("---------------------------------------------------");
    Console.WriteLine("Bem-vindo ao sistema de gerenciamento de biblioteca");
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("------CRUD - Livros----------");
    Console.WriteLine("1 - Cadastrar livro");
    Console.WriteLine("2 - Editar livro");
    Console.WriteLine("3 - Consultar um livro");
    Console.WriteLine("4 - Listar livros");
    Console.WriteLine("5 - Remover Livro");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("------CRUD - Usuários--------");
    Console.WriteLine("6 - Cadastrar usuário");
    Console.WriteLine("7 - Editar usuário");
    Console.WriteLine("8 - Consultar um usuário");
    Console.WriteLine("9 - Listar usuários");
    Console.WriteLine("10 - Remover Usuário");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("------Empréstimos------------");
    Console.WriteLine("11 - Realizar empréstimo");
    Console.WriteLine("12 - Devolver livro");
    Console.WriteLine("13 - Listar empréstimos");
    Console.WriteLine("-----------------------------");
    Console.WriteLine("14 - Sair");
    Console.Write("Digite o número da opção desejada:");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Cadastrar livro
            Livro livro = new();
            
            do
            {
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

            Console.WriteLine("-----------Livro cadastrado com Sucesso------------");
            break;
        case "2":
        // Editar livro
            Console.WriteLine("---------------Edição de Livros------------------");

            if (livros.Count == 0)
            {
                Console.WriteLine("Não há Livros cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            Livro livroEditar = null;
            bool continuarConsultaLivroEdicao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ISBN do livro que deseja consultar:");
                    string isbnLivroConsultar = Console.ReadLine();
                    livroEditar = livros.Find(l => l.ISBN == isbnLivroConsultar);

                    if (livroEditar == null)
                    {
                        Console.WriteLine("Livro não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaLivroEdicao = tentarNovamente.ToUpper() == "S";
                    } else
                        continuarConsultaLivroEdicao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaLivroEdicao == true);  

            bool continuarEdicao = true;

            if (livroEditar !=  null && continuarConsultaLivroEdicao == false)
            {
                do
                {
                    try
                    {
                        Console.WriteLine("Digite o novo título do livro:");
                        livroEditar.Titulo = Console.ReadLine();

                        Console.WriteLine("Digite o novo autor do livro:");
                        livroEditar.Autor = Console.ReadLine();

                        Console.WriteLine("Digite o novo ISBN do livro:");
                        livroEditar.ISBN = Console.ReadLine();

                        Console.WriteLine("Digite o novo ano de publicação do livro:");
                        livroEditar.AnoPublicacao = int.Parse(Console.ReadLine());

                        continuarEdicao = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao cadastrar livro, tente novamente! Ex:" + ex.Message);
                    }
                } while (continuarEdicao == true);
            }
            
            break;
        case "3":
        // Consultar um livro
            Console.WriteLine("---------------Consulta de Livros------------------");

            if (livros.Count == 0)
            {
                Console.WriteLine("Não há Livros cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            Livro livroConsultar = null;
            bool continuarConsultaLivro = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ISBN do livro que deseja consultar:");
                    string isbnLivroConsultar = Console.ReadLine();
                    livroConsultar = livros.Find(l => l.ISBN == isbnLivroConsultar);

                    if (livroConsultar == null)
                    {
                        Console.WriteLine("Livro não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaLivro = tentarNovamente.ToUpper().Equals("S");
                    }else
                        continuarConsultaLivro = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaLivro == true);  

            if( livroConsultar != null)
            {
                livroConsultar.Apresentar();

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(); 
            }            

            break;       
        case "4":
        // Listar livros
            
            Console.WriteLine("-------------Listagem de livros--------------------");

            if (livros.Count > 0)
            {
                livros.ForEach(l => l.ApresentarListagem());
            }
            else
                Console.WriteLine("Não há Livros cadastrados!");

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();

            break;
        case "5":
        // Remover Livro
            
            Console.WriteLine("-------------Remoção de Livro---------------------");

            if (livros.Count == 0)
            {
                Console.WriteLine("Não há Livros cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Livros:");
            livros.ForEach(l => l.ApresentarListagem());
            
            Livro livroRemover = null;
            bool continuarConsultaLivroRemocao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do livro que deseja remover:");
                    int idLivroRemover = int.Parse(Console.ReadLine());
                    livroRemover = livros.Find(l => l.Id == idLivroRemover);

                    if (livroRemover  == null)
                    {
                        Console.WriteLine("Livro não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaLivroRemocao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaLivroRemocao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaLivroRemocao == true);
             
            if (livroRemover != null)
            {
                livros.Remove(livroRemover);

                Console.WriteLine("Livro removido com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(); 
            }

            break;
               
        case "6":
        // Cadastrar usuário
            Usuario usuario = new();
            
            do 
            {
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
        case "7":
        // Editar usuário
            Console.WriteLine("---------------Edição de Usuários------------------");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            usuarios.ForEach(u => u.ApresentarListagem());
            
            Usuario usuarioEditar = null;
            bool continuarConsultaUsuarioEdicao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o Id do usuário que deseja editar:");
                    int idUsuarioEditar = int.Parse(Console.ReadLine());
                    usuarioEditar = usuarios.Find(u => u.Id == idUsuarioEditar);

                    if (usuarioEditar == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUsuarioEdicao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else
                        continuarConsultaUsuarioEdicao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUsuarioEdicao == true);

            bool continuarEdicaoUsuario = true;

            if (usuarioEditar !=  null && continuarConsultaUsuarioEdicao == false)
            {
                do 
                {
                    Console.WriteLine("---------------Edição de usuário-----------------");
                    try
                    {
                        Console.WriteLine("Digite o novo nome do usuário:");
                        usuarioEditar.Nome = Console.ReadLine();

                        Console.WriteLine("Digite o novo email do usuário:");
                        usuarioEditar.Email = Console.ReadLine();

                        continuarEdicaoUsuario = false;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao cadastrar usuário, tente novamente! Ex:" + ex.Message);
                    }
                } while (continuarEdicaoUsuario == true);

                Console.WriteLine("Usuário editado com sucesso!");
                usuarioEditar.Apresentar();
                Console.WriteLine("Pressione qualquer tecla para continuar...");
            }
            
            break;
        case "8":
        // Consultar um usuário
            Console.WriteLine("---------------Consulta de Usuários------------------");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            Usuario usuarioConsultar = null;
            bool continuarConsultaUsuario = true;
            do
            {
                
                try
                {
                    Console.WriteLine("Digite o email do usuário que deseja consultar:");
                    string emailUsuarioConsultar = Console.ReadLine();
                    usuarioConsultar = usuarios.Find(u => u.Email == emailUsuarioConsultar);

                    if (usuarioConsultar  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUsuario = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUsuario = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUsuario == true);

            if( usuarioConsultar != null)
            {
                usuarioConsultar.Apresentar();

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey(); 
            }    

            break;
        case "9":
        // Listar usuários
            
            Console.WriteLine("-------------Listagem de usuários------------------");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
            
            usuarios.ForEach(u => u.ApresentarListagem());
            
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
        case "10":
        // Remover Usuário
            
            Console.WriteLine("-------------Remoção de Usuário-------------------");

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            usuarios.ForEach(u => u.ApresentarListagem());
            
            Usuario usuarioRemover = null;
            bool continuarConsultaUsuarioRemocao = true;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do usuário que deseja remover:");
                    int idUsuarioRemover = int.Parse(Console.ReadLine());
                    usuarioRemover = usuarios.Find(u => u.Id == idUsuarioRemover);

                    if (usuarioRemover  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUsuarioRemocao = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUsuarioRemocao = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUsuarioRemocao == true);
             
            if (usuarioRemover != null)
            {
                usuarios.Remove(usuarioRemover);
                Console.WriteLine("Usuário removido com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            break;
        
        case "11":
        // Realizar empréstimo
            
            
            Console.WriteLine("-------------Cadastro de empréstimo----------------");

            if (livros.Count == 0)
            {
                Console.WriteLine("Não há livros cadastrados, realize o cadastro e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Livros:");
            livros.ForEach(l => l.ApresentarListagem());

            Emprestimo emprestimo = new(){
                Id = ContadorEmprestimos++
            };

            bool continuarConsultaLivroEmprestimo = true;
            Livro livroConsultarEmprestimo = null;
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do livro que desejado:");
                    int idLivroEmprestimo = int.Parse(Console.ReadLine());
                    livroConsultarEmprestimo = livros.Find(l => l.Id == idLivroEmprestimo);

                    if (livroConsultarEmprestimo == null)
                    {
                        Console.WriteLine("Livro não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaLivroEmprestimo = tentarNovamente.ToUpper().Equals("S");
                    }else
                        continuarConsultaLivroEmprestimo = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Livro não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaLivroEmprestimo == true);  

            if( livroConsultarEmprestimo != null)
            {
                emprestimo.Livro = livroConsultarEmprestimo;
            } 

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Não há usuários cadastrados, realize o cadastro e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de Usuários:");
            usuarios.ForEach(u => u.ApresentarListagem());
            
            Usuario usuarioConsultarEmprestimo = null;
            bool continuarConsultaUsuarioEmprestimo = true;
            do
            {   
                try
                {
                    Console.WriteLine("Digite o ID do usuário que desejado:");
                    int idUsuarioEmprestimo = int.Parse(Console.ReadLine());
                    usuarioConsultarEmprestimo = usuarios.Find(u => u.Id == idUsuarioEmprestimo);

                    if (usuarioConsultarEmprestimo  == null)
                    {
                        Console.WriteLine("Usuário não encontrado, Deseja tentar novamente! (S/N)");
                        string tentarNovamente = Console.ReadLine();
                        continuarConsultaUsuarioEmprestimo = tentarNovamente.ToUpper().Equals("S");
                    } 
                    else 
                        continuarConsultaUsuarioEmprestimo = false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Usuário não encontrado, tente novamente! EX:"+ ex.Message);
                }  
            } while (continuarConsultaUsuarioEmprestimo == true);

            if( usuarioConsultarEmprestimo != null)
            {
                emprestimo.Usuario = usuarioConsultarEmprestimo;
            }   

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

            if (emprestimo.DataDevolucao != DateTime.MinValue)
            {
                Console.WriteLine("Empréstimo realizado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            emprestimos.Add(emprestimo);
            break;
        case "12":
        // Devolver livro
            bool devolvido = false;
            string mensagem = "";
            Console.WriteLine("------------Devolução de empréstimo----------------");

            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Não há empréstimos, realize um e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }

            Console.WriteLine("-------------Lista de empréstimos:"); 
            emprestimos.ForEach( e => e.Apresentar());
            
            do
            {
                try
                {
                    Console.WriteLine("Digite o ID do empréstimo:");
                    int emprestimoId = int.Parse(Console.ReadLine());
                    mensagem = emprestimos.Find(e => e.Id == emprestimoId).DataDevolucao > DateTime.Now ? "Empréstimo no prazo" : "Empréstimo atrasado";
                    emprestimos.Remove(emprestimos.Find(e => e.Id == emprestimoId));
                    devolvido = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Empréstimo não encontrado, tente novamente!");
                    Console.WriteLine("Deseja tentar novamente? (S/N)");
                    string tentarNovamente = Console.ReadLine();
                    devolvido = tentarNovamente.ToUpper().Equals("N");
                }
                
            } while (devolvido == false);
           
            if (devolvido == true)
            {   
                Console.WriteLine("-------------Devolução de empréstimo----------------");
                Console.WriteLine(mensagem);
                Console.WriteLine("Livro devolvido com sucesso!");
                Console.WriteLine("Lista de empréstimos atualizada:");
                emprestimos.ForEach( e => e.Apresentar());   
            }

            break;
        case "13":
        // Listar empréstimos
            
            Console.WriteLine("-------------Listagem de empréstimos--------------");

            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Não há empréstimos, realize um e tente novamente!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                break;
            }
           
            emprestimos.ForEach( e => e.Apresentar());

            Console.WriteLine("Pressione qualquer tecla para continuar...");

            Console.ReadKey();
            break;
        
        case "14":
        // Sair
            stop = true;
            break;
        default:
            
            Console.WriteLine("Opção inválida");
            opcao = "";
            break;  
    }

} while (stop == false);

