

namespace Tabuleiro
{
    class Peca
    {
        public Posicao PosicaoDaPeca { get; set; }
        public Cor CorDaPeca { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro TabuleiroDaPeca { get; protected set; }

        public Peca(Cor corDaPeca, Tabuleiro tabuleiroDaPeca)
        {
            PosicaoDaPeca = null;
            CorDaPeca = corDaPeca;
            TabuleiroDaPeca = tabuleiroDaPeca;
            QteMovimentos = 0;
        }
    }
}
