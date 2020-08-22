

namespace Tabuleiro
{
    abstract class Peca
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
        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] tempMatrix = MovimentosPossiveis();
            for (int i = 0; i < TabuleiroDaPeca.Linhas; i++)
            {
                for (int j = 0; j < TabuleiroDaPeca.Colunas; j++)
                {
                    if (tempMatrix[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
