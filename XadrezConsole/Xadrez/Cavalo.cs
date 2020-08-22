using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, ControleTabuleiro tab) : base(cor, tab) { }
        public override string ToString()
        {
            return "C";
        }
        public override bool[,] MovimentosPossiveis()
        {
            throw new System.NotImplementedException();
        }
    }
}
