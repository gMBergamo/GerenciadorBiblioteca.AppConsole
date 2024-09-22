using System.Text.RegularExpressions;

namespace GerenciadorBiblioteca.AppConsole
{

    public partial class Usuario
    {
        private int _id = 0;
        private string? _nome;
        private string? _email;

        public int Id
        {
            get => _id;  
            set { 
                    if (value < 0)
                    {
                        throw new ArgumentException("O id do usuário não pode ser negativo");
                    }

                    _id = value; 
                }
        }

        public string Nome
        {
            get => _nome ?? "NA";
            set { 
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("O nome do usuário não pode ser vazio");
                    } else if (value.Length > 150)
                    {
                        throw new ArgumentException("O nome do usuário não pode ter mais de 150 caracteres");
                    }

                    _nome = value; 
                }
        }

        public string Email
        {
            get => _email ?? "NA";
            set { 
                    Regex regex = EmailRegex();
                    if (string.IsNullOrEmpty(value))
                    {
                        throw new ArgumentException("O email do usuário não pode ser vazio");
                    } else if (!regex.IsMatch(value))
                    {
                        throw new ArgumentException("O email do usuário não é válido");
                    }

                    _email = value; 
                }
        }

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
    }
    
}