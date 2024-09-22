namespace GerenciadorBiblioteca.AppConsole
{
    public class Emprestimo
    {
        private int _id = 0;
        private Livro? _livro;
        private Usuario? _usuario;
        private readonly DateTime _dataEmprestimo = DateTime.Now;
        private DateTime _dataDevolucao;

        public int Id
        {
            get => _id;
            set {
                    if (value < 0)
                    {
                        throw new ArgumentException("O id do empréstimo não pode ser negativo");
                    }

                    _id = value;
                }
        }

        public Livro Livro
        {
            get => _livro ?? throw new ArgumentException("O livro do empréstimo não pode ser nulo");
            set => _livro = value;
        }

        public Usuario Usuario
        {
            get => _usuario ?? throw new ArgumentException("O usuário do empréstimo não pode ser nulo");
            set => _usuario = value;
        }

        public DateTime DataEmprestimo
        {
            get => _dataEmprestimo;
        }

        public DateTime DataDevolucao
        {
            get => _dataDevolucao;
            set {
                    if (value < _dataEmprestimo)
                    {
                        throw new ArgumentException("A data de devolução não pode ser anterior à data de empréstimo");
                    }

                    _dataDevolucao = value;
                }
        }


    }
}