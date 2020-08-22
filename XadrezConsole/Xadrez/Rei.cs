using Tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "K";
        }
    }
}
