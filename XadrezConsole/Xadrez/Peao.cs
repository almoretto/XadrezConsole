using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        public Peao(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "P";
        }
    }
}
