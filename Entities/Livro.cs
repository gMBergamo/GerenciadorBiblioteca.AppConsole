namespace GerenciadorBiblioteca.AppConsole
{
    public class Livro
    {
        private int _id = 0;
        private string? _titulo;
        private string? _autor;
        private string? _ISBN;
        private int _anoPublicacao;

        public int Id 
        {
            get => _id;
            set { 
                    if (value < 0)
                    {
                        throw new ArgumentException("O id do livro não pode ser negativo");
                    }
                    
                    _id = value;
                }
        }

        public string Titulo
        {
            get => _titulo ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("O título do livro não pode ser vazio");
                    } else if (value.Length > 150)
                    {
                        throw new ArgumentException("O título do livro não pode ter mais de 100 caracteres");
                    }

                    _titulo = value; 
                }
        }
        public string Autor
        {
            get => _autor ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("O autor do livro não pode ser vazio");
                    } else if (value.Length > 100)
                    {
                        throw new ArgumentException("O autor do livro não pode ter mais de 100 caracteres");
                    }

                    _autor = value; 
                }
        }

        public string ISBN
        {
            get => _ISBN ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("O ISBN do livro não pode ser vazio");
                    } else if (value.Length > 13)
                    {
                        throw new ArgumentException("O ISBN do livro não pode ter mais de 13 caracteres");
                    }

                    _ISBN = value; 
                }
        }

        public int AnoPublicacao
        {
            get => _anoPublicacao;
            set { 
                    if (value < 0)
                    {
                        throw new ArgumentException("O ano de publicação do livro não pode ser negativo");
                    } else if (value > DateTime.Now.Year)
                    {
                        throw new ArgumentException("O ano de publicação do livro não pode ser maior que o ano atual");
                    }

                    _anoPublicacao = value; 
                }
        }

        public void Apresentar()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Ano de Publicação: {AnoPublicacao}");
        }

        public void ApresentarListagem()
        {
            Console.WriteLine($"ID: {Id} - Título: {Titulo} - ISBN: {ISBN}");
        }

    }
}

