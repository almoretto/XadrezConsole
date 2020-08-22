using Tabuleiro;

namespace Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "B";
        }
    }
}
