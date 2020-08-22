

namespace Tabuleiro
{
    class Peca
    {
        public Posicao PosicaoDaPeca { get; set; }
        public Cor CorDaPeca { get; protected set; }
        public int QteMovimentos { get; protected set; }
        public Tabuleiro TabuleiroDaPeca { get; protected set; }

        public Peca(Posicao posicaoDaPeca, Cor corDaPeca, Tabuleiro tabuleiroDaPeca)
        {
            PosicaoDaPeca = posicaoDaPeca;
            CorDaPeca = corDaPeca;
            TabuleiroDaPeca = tabuleiroDaPeca;
            QteMovimentos = 0;
        }
    }
}
