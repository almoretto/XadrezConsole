using Tabuleiro;

namespace Xadrez
{
    class Rainha : Peca
    {
        public Rainha(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "Q";
        }
        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
    }
}
