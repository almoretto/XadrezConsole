using Tabuleiro;

namespace Xadrez
{
    class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "Q";
        }
    }
}
