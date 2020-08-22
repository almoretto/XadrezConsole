

namespace Tabuleiro
{
    class Peca
    {
        public Posicao PosicaoDaPeca { get; set; }
        public Cor CorDaPeca { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public ControleTabuleiro TabuleiroDaPeca { get; protected set; }

        public Peca(Cor corDaPeca, ControleTabuleiro tabuleiroDaPeca)
        {
            PosicaoDaPeca = null;
            CorDaPeca = corDaPeca;
            TabuleiroDaPeca = tabuleiroDaPeca;
            QteMovimentos = 0;
        }
    }
}
