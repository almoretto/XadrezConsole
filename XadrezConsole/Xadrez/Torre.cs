using Tabuleiro;

namespace Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "T";
        }
    }
}
